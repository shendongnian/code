    public static class StringExtensions
    {
       public static string Repeat(this char chatToRepeat, int repeat) {
         
           return new string(chatToRepeat,repeat);
       }
       public  static string Repeat(this string stringToRepeat,int repeat)
       {
           var builder = new StringBuilder(repeat);
           for (int i = 0; i < repeat; i++) {
               builder.Append(stringToRepeat);
           }
           return builder.ToString();
       }
    }
