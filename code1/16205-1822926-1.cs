    public static class StrExtension
    {
       public static string twice(this string str) { return str + str; }
    }
    
    ...
    dynamic x = "Yo";
    StrExtension.twice(x);
