    using CurrentColorScheme = Outlook2007ColorScheme;
    public static class ColorScheme
    {
       public static Color ApplyColorScheme(Color c)
       {
           return CurrentColorScheme.ApplyColorScheme(c);
       }
       public static Something DoSomethingElse(Param a, Param b)
       {
           return CurrentColorScheme.DoSomethingElse(a, b);
       }
    }
