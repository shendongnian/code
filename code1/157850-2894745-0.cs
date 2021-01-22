    public static class EightQueens
        {
            static   int[] board = new int[8];
            static int MaxRows = 8, MaxCols = 8;
            public static int[] GetPosition()
            {
                if (GetPosition(0)) return board;
                else return null;
            }
            public static bool IsCollision(int row, int col)
            {
                for (int i = 0; i < col; i++)
                {
                    if (board[i] == row) return true; // Same Row
                    if ((board[i] + col - i == row) || (board[i] - col + i == row))
                        return true;
                }
                return false;
    
            }
            public static bool GetPosition(int col)
            {
                if (col == MaxCols) return true;
                for (int row = 0; row < MaxRows; row++)
                    if (!IsCollision(row, col))
                    {
                        board[col] = row;
                        if (GetPosition(col + 1)) return true;
                    }
                return false;
    
            }
        }
