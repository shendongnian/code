        private const int Size = 8;
        private static readonly bool[,] chessboard = new bool[Size, Size];
        //The Rows are 8, numbered from 0 to 7.
        //The Columns are 8, numbered from 0 to 7.
        //The left diagonals are 15, numbered from -7 to 7. following formula : leftDiag = col - row.
        //The right diagonals are 15, numbered from 0 to 14 by the formula: rightDiag = col + row.
        private static readonly HashSet<int> AttackedRows = new HashSet<int>();
        private static readonly HashSet<int> AttackedCols = new HashSet<int>();
        private static readonly HashSet<int> AttackedLeftDiagonals = new HashSet<int>();
        private static readonly HashSet<int> AttackedRightDiagonals = new HashSet<int>();
        private static int solutionsFound;
        private static void Main(string[] args)
        {
            PutQueens(0);
            Console.WriteLine(solutionsFound);
        }
        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintBoard();
                solutionsFound++;
            }
            else
            {
                for (var col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositons(row, col);
                        PutQueens(row + 1);
                        UnMarkAllAttackedPositons(row, col);
                    }
                }
            }
        }
        private static void UnMarkAllAttackedPositons(int row, int col)
        {
            AttackedRows.Remove(row);
            AttackedCols.Remove(col);
            AttackedLeftDiagonals.Remove(col - row);
            AttackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }
        private static void MarkAllAttackedPositons(int row, int col)
        {
            AttackedRows.Add(row);
            AttackedCols.Add(col);
            AttackedLeftDiagonals.Add(col - row);
            AttackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }
        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccuppied = AttackedCols.Contains(col) || AttackedRows.Contains(row)
                                    || AttackedLeftDiagonals.Contains(col - row)
                                    || AttackedRightDiagonals.Contains(col + row);
            return !positionOccuppied;
        }
        private static void PrintBoard()
        {
            for (var row = 0; row < Size; row++)
            {
                for (var col = 0; col < Size; col++)
                {
                    Console.Write(chessboard[row, col] ? "Q " : "- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
