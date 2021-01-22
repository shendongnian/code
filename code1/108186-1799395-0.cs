     public static string CenterWithRespectTo(string s, string against) {
         if (s.Length > against.Length) {
             throw new InvalidOperationException();
         }
         int halfSpace = (against.Length - s.Length) / 2;
         return s.PadLeft(halfSpace + s.Length).PadRight(against.Length);
     }
