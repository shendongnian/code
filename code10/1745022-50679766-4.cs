    using System;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine(isWinFor('X')); // false
                Console.WriteLine(isWinFor('O')); // false
                board[0, 0] = 'X';
                board[1, 1] = 'X';
                board[2, 2] = 'X';
                Console.WriteLine(isWinFor('X')); // true
                Console.WriteLine(isWinFor('O')); // false
            }
            static bool isWinFor(char player)
            {
                for (int line = 0; line < winningLines.GetUpperBound(0); ++line)
                {
                    bool won = true;
                    for (int coord = 0; coord < 3; ++coord)
                    {
                        var p = winningLines[line, coord];
                        if (board[p.X, p.Y] != player)
                            won = false;
                    }
                    if (won)
                        return true;
                }
                return false;
            }
            static readonly char[,] board = new char[3,3];
            static readonly (int X, int Y)[,] winningLines =
            {
                {(0, 0), (0, 1), (0, 2)},
                {(0, 0), (1, 1), (2, 2)},
                {(0, 0), (1, 0), (2, 0)},
                {(0, 1), (1, 1), (2, 1)},
                {(0, 2), (1, 2), (2, 2)},
                {(1, 0), (1, 1), (1, 2)},
                {(2, 0), (1, 2), (2, 2)},
                {(0, 2), (1, 1), (2, 0)}
            };
        }
    }
