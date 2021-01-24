    public static List<string> ListofSimpleString(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => Enumerable.Range(0,10).Select(y => (char)_rand.Next(255)).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString2(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => Enumerable.Range(0, 10).Select(y => (char)_rand.Next(26,46)).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString3(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x =>  _rand.Next(1000).ToString())
                      .ToList();
    }
    public static List<string> ListofSimpleString4(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => _rand.Next(100).ToString())
                      .ToList();
    }
    public static List<decimal> ListOfDecimal(int scale)
    {
       return Enumerable.Range(0, scale)
                      .Select(x => _rand.NextDecimal())
                      .ToList();
    }
