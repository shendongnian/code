    public static class Extensions
    {
       public static T[,] ToRectangularArray<T>(this IReadOnlyList<T[]> arrays)
       {
          var ret = new T[arrays.Count, arrays[0].Length];
          for (var i = 0; i < arrays.Count; i++)
             for (var j = 0; j < arrays[0].Length; j++)           
                ret[i, j] = arrays[i][j];
          return ret;
       }
    }
