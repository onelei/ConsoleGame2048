using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConsoleGame2048
{
    enum MoveDirection
    {
        None,
        Left,
        Right,
        Up,
        Down,
    }

    private const int MaxNum = 4;

    private MoveDirection m_MoveType = MoveDirection.None;

    static void Main(string[] args)
    {
        int[,] array_4X4 = new int[,] 
            {
                { 0,0,2,0 }, 
                { 2,2,2,2 }, 
                { 0,2,0,2 }, 
                { 4,0,0,4 } 
            };

        PrintTheList(array_4X4);

        int[,] tempHangs = null;

        // 向右移动;
        // tempHangs = Update(MoveDirection.Right, array_4X4);

        // 向左移动;
        //  tempHangs = Update(MoveDirection.Left, array_4X4);

        // 向上移动;
        //   tempHangs = Update(MoveDirection.Up, array_4X4);

        // 向下移动;
        tempHangs = Update(MoveDirection.Down, array_4X4);

        PrintTheList(tempHangs);

        Console.ReadLine();
    }

    static int[,] Update(MoveDirection _type, int[,] array_4x4)
    {
        int[,] tempHangs = null;
        switch (_type)
        {
            case MoveDirection.Right:
                {
                    tempHangs = UpdateMoveRight(array_4x4);
                }
                break;
            case MoveDirection.Left:
                {
                    tempHangs = UpdateMoveLeft(array_4x4);
                }
                break;
            case MoveDirection.Up:
                {
                    tempHangs = UpdateMoveUp(array_4x4);
                }
                break;
            case MoveDirection.Down:
                {
                    tempHangs = UpdateMoveDown(array_4x4);
                }
                break;
        }
        return tempHangs;
    }

    // 向左移动;
    static int[,] UpdateMoveLeft(int[,] array_4x4)
    {
        int[,] tempHangs = null;
        tempHangs = LeftMove(array_4x4);
        tempHangs = LeftAddNumber(tempHangs);
        tempHangs = LeftMove(tempHangs);
        return tempHangs;
    }

    // 向右移动;
    static int[,] UpdateMoveRight(int[,] array_4x4)
    {
        int[,] tempHangs = null;
        tempHangs = RightMove(array_4x4);
        tempHangs = RightAddNumber(tempHangs);
        tempHangs = RightMove(tempHangs);
        return tempHangs;
    }

    // 向上移动;
    static int[,] UpdateMoveUp(int[,] array_4x4)
    {
        int[,] tempHangs = null;
        tempHangs = UpMove(array_4x4);
        tempHangs = UpAddNumber(tempHangs);
        tempHangs = UpMove(tempHangs);
        return tempHangs;
    }

    // 向下移动;
    static int[,] UpdateMoveDown(int[,] array_4x4)
    {
        int[,] tempHangs = null;
        tempHangs = DownMove(array_4x4);
        tempHangs = DownAddNumber(tempHangs);
        tempHangs = DownMove(tempHangs);
        return tempHangs;
    }

    // 打印出列表;
    static void PrintTheList(int[,] array_4X4)
    {
        if (array_4X4 == null || array_4X4.Length <= 0)
        {
            return;
        }
        Console.WriteLine("****************");
        for (int i = 0; i < MaxNum; ++i)
        {
            for (int j = 0; j < MaxNum; ++j)
            {
                Console.Write(array_4X4[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("****************");
    }

    // 移动向最右边;
    static int[,] RightMove(int[,] array_4x4)
    {
        for (int i = 0; i < MaxNum; ++i)
        {
            for (int j = MaxNum - 1; j >= 0; --j)
            {
                int now = array_4x4[i, j];
                int tempJ = j;
                // 当前为0,找下一个不是0的替换为当前的;
                if (now == 0 && j - 1 >= 0)
                {
                    while (j - 1 >= 0 && array_4x4[i, j - 1] == 0)
                    {
                        --j;
                    }
                    if (j - 1 >= 0)
                    {
                        array_4x4[i, tempJ] = array_4x4[i, j - 1];
                        array_4x4[i, j - 1] = 0;
                        j = tempJ;
                    }
                }
            }
        }
        return array_4x4;
    }

    // 移动向最左边;
    static int[,] LeftMove(int[,] array_4x4)
    {
        for (int i = 0; i < MaxNum; ++i)
        {
            for (int j = 0; j < MaxNum; ++j)
            {
                int now = array_4x4[i, j];
                int tempJ = j;
                // 当前为0,找下一个不是0的替换为当前的;
                if (now == 0 && j + 1 < MaxNum)
                {
                    while (j + 1 < MaxNum && array_4x4[i, j + 1] == 0)
                    {
                        ++j;
                    }
                    if (j + 1 < MaxNum)
                    {
                        array_4x4[i, tempJ] = array_4x4[i, j + 1];
                        array_4x4[i, j + 1] = 0;
                        j = tempJ;
                    }
                }
            }
        }
        return array_4x4;
    }

    // 移动向最上边;
    static int[,] UpMove(int[,] array_4x4)
    {
        for (int j = 0; j < MaxNum; ++j)
        {
            for (int i = 0; i < MaxNum; ++i)
            {
                int now = array_4x4[i, j];
                int tempI = i;
                // 当前为0,找下一个不是0的替换为当前的;
                if (now == 0 && i + 1 < MaxNum)
                {
                    while (i + 1 < MaxNum && array_4x4[i + 1, j] == 0)
                    {
                        ++i;
                    }
                    if (i + 1 < MaxNum)
                    {
                        array_4x4[tempI, j] = array_4x4[i + 1, j];
                        array_4x4[i + 1, j] = 0;
                        i = tempI;
                    }
                }
            }
        }
        return array_4x4;
    }

    // 移动向最下边;
    static int[,] DownMove(int[,] array_4x4)
    {
        for (int j = 0; j < MaxNum; ++j)
        {
            for (int i = MaxNum - 1; i >= 0; --i)
            {
                int now = array_4x4[i, j];
                int tempI = i;
                // 当前为0,找下一个不是0的替换为当前的;
                if (now == 0 && i - 1 >= 0)
                {
                    while (i - 1 >= 0 && array_4x4[i - 1, j] == 0)
                    {
                        --i;
                    }
                    if (i - 1 >= 0)
                    {
                        array_4x4[tempI, j] = array_4x4[i - 1, j];
                        array_4x4[i - 1, j] = 0;
                        i = tempI;
                    }
                }
            }
        }
        return array_4x4;
    }


    // Left将数字相加;
    static int[,] LeftAddNumber(int[,] array_4x4)
    {
        for (int i = 0; i < MaxNum; ++i)
        {
            for (int j = 0; j < MaxNum; ++j)
            {
                // 如果当前的和前一个相等则相加,否则就将当前要找的换成下一个,接着下一个找;
                int now = array_4x4[i, j];
                if (j + 1 < MaxNum && now == array_4x4[i, j + 1])
                {
                    array_4x4[i, j] += array_4x4[i, j + 1];
                    array_4x4[i, j + 1] = 0;
                }
            }
        }
        return array_4x4;
    }

    // Right将数字相加;
    static int[,] RightAddNumber(int[,] array_4x4)
    {
        for (int i = 0; i < MaxNum; ++i)
        {
            for (int j = MaxNum - 1; j >= 0; --j)
            {
                // 如果当前的和前一个相等则相加,否则就将当前要找的换成下一个,接着下一个找;
                int now = array_4x4[i, j];
                if (j - 1 >= 0 && now == array_4x4[i, j - 1])
                {
                    array_4x4[i, j] += array_4x4[i, j - 1];
                    array_4x4[i, j - 1] = 0;
                }
            }
        }
        return array_4x4;
    }

    // Up将数字相加;
    static int[,] UpAddNumber(int[,] array_4x4)
    {
        for (int j = 0; j < MaxNum; ++j)
        {
            for (int i = 0; i < MaxNum; ++i)
            {
                // 如果当前的和前一个相等则相加,否则就将当前要找的换成下一个,接着下一个找;
                int now = array_4x4[i, j];
                if (i + 1 < MaxNum && now == array_4x4[i + 1, j])
                {
                    array_4x4[i, j] += array_4x4[i + 1, j];
                    array_4x4[i + 1, j] = 0;
                }
            }
        }
        return array_4x4;
    }

    // Down将数字相加;
    static int[,] DownAddNumber(int[,] array_4x4)
    {
        for (int j = 0; j < MaxNum; ++j)
        {
            for (int i = MaxNum - 1; i >= 0; --i)
            {
                // 如果当前的和前一个相等则相加,否则就将当前要找的换成下一个,接着下一个找;
                int now = array_4x4[i, j];
                if (i - 1 >= 0 && now == array_4x4[i - 1, j])
                {
                    array_4x4[i, j] += array_4x4[i - 1, j];
                    array_4x4[i - 1, j] = 0;
                }
            }
        }
        return array_4x4;
    }
}

