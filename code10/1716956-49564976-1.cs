    public static class MyClass
    {
      public static string GetDefault(this str, string defaultVal)
     {
       return string.IsNullOrEmpty(str) ? defaultVal : str;
     }
    }
