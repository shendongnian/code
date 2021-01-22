    public static class MyExtensions
    {
      public static string TrimLastCharacter(this String str)
      {
         if(String.IsNullOrEmpty(str)){
            return str;
         } else {
            return str.TrimEnd(str[str.Length - 1]);
         }
      }
    }
