    public static class Exts
    {
         public static int ToInt32(this string x)
         {
              int result = 0;
              int.TryParse(x, out result);
              return result;
         }
    }
