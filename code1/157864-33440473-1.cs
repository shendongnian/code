    //----N Queens ----
    public static bool NQueens(bool[,] board, int x)
    {
          for (int y = 0; y < board.GetLength(1); y++)
          {
              if (IsAllowed(board, x, y))
              {
                   board[x, y] = true;
                   if (x == board.GetLength(0) - 1 || NQueens(board, x + 1))
                   {
                       return true;
                   }
                   board[x, y] = false;
              }
         }
         return false;
    }
    //verify diagonals, column and row from i=0 to x because from x to down it dont put anything
    private static bool IsAllowed(bool[,] board, int x, int y)
    {
        for (int i = 0; i <= x; i++)
        {
            if (board[i, y] || (i <= y && board[x - i, y - i]) || (y + i < board.GetLength(0) && board[x - i, y + i]))
            {
                return false;
            }
        }
        return true;
    }
