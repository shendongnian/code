    // assuming that the array is in row-major order...
    public static bool IsInBorder(this BoardCell[,] board, int x, int y) {
        return x == board.GetLowerBound(1) || x == board.GetUpperBound(1) ||
               y == board.GetLowerBound(0) || y == board.GetUpperBound(0);
    }
