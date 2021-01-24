    public static List<string> ListofSimpleString(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => Enumerable.Range(0,10).Select(y => (char)_rand.Next(255)).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString2(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => Enumerable.Range(0, 10).Select(y => (char)_rand.Next(48,95)).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString4(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => _rand.Next(10).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString5(int scale)
    {
       return Enumerable.Range(0, scale)
                     .Select(x => "duplicate value")
                     .ToList();
    }
