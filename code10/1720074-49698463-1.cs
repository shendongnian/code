    public static class UnitTest
    {
      [Conditional("UnitTest")]
      public static void Log(string s)
      {
        Console.WriteLine(s);
      }
    }
