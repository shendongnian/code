    public static class MultiDimensionalArrayExtensions
    {
      public static IEnumerable<T> Row<T>(this T[,] array, int row)
      {
        var columnLower = array.GetLowerBound(1);
        var columnUpper = array.GetUpperBound(1);
    
        for (int i = columnLower; i <= columnUpper; i++)
        {
          yield return array[row, i];
        }
      }
    
      public static IEnumerable<T> Column<T>(this T[,] array, int column)
      {
        var rowLower = array.GetLowerBound(0);
        var rowUpper = array.GetUpperBound(0);
    
        for (int i = rowLower; i <= rowUpper; i++)
        {
          yield return array[i, column];
        }
      }
    
      public static IEnumerable<T> Diagonal<T>(this T[,] array,
                                               DiagonalDirection direction)
      {
        var rowLower = array.GetLowerBound(0);
        var rowUpper = array.GetUpperBound(0);
        var columnLower = array.GetLowerBound(1);
        var columnUpper = array.GetUpperBound(1);
    
        for (int row = rowLower, column = columnLower;
             row <= rowUpper && column <= columnUpper;
             row++, column++)
       {
          int realColumn = column;
          if (direction == DiagonalDirection.DownLeft)
          realColumn = columnUpper - columnLower - column;
    
          yield return array[row, realColumn];
        }
      }
    
      public enum DiagonalDirection
      {
        DownRight,
        DownLeft
      }
    }
