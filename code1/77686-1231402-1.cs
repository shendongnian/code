    public static class BinaryExtension
    {
      public static IEnumerable<int> ToUIntVar(this int value)
      {
         string binary = Convert.ToString(value, 2);    
         for (int i = binary.Length; i > 0; i -= 7)
         {
            if (i >= 7)
            {
               if (i == binary.Length)
                  yield return Convert.ToInt32(binary.Substring(i - 7, 7).PadLeft(8, '0'), 2);
               else
                   yield return Convert.ToInt32("1" + binary.Substring(i - 7, 7), 2);
             }
             else if (binary.Length < 7)
               yield return Convert.ToInt32(binary.Substring(0, i).PadLeft(8, '0'), 2);
             else
               yield return Convert.ToInt32("1" + binary.Substring(0, i).PadLeft(7, '0'), 2);
          }
      }
    }
