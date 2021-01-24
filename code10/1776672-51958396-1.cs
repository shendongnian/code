    static void Test()
    {
      string[] text =
      {
        "//some data",
        "/some data",
        "for i = 1 to 10",
        "foreach i",
      };
      foreach (string s in text)
      {
        PatternMatch pm = PatternMatch.TryMatch(s);
        if (pm == null)
        {
          Console.WriteLine("NO MATCH: {0}", s);
        }
        else
        {
          Console.WriteLine("MATCHED:  {0}", s);
          Console.WriteLine("  Prefix: len={0}, value={1}", pm.Prefix.Length, pm.Prefix );
          Console.WriteLine("  Suffix: len={0}, value={1}", pm.Suffix.Length, pm.Suffix ); 
        }
      }
    }
