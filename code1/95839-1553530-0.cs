    static void Main(string[] _args)
    {
      DateTime d1 = DateTime.Parse("7/4/2006", CultureInfo.CreateSpecificCulture("en-GB"));
      DateTime d2 = DateTime.Parse("8/1/2006", CultureInfo.CreateSpecificCulture("en-GB"));
      DateTime d3 = DateTime.Parse("16/7/2006", CultureInfo.CreateSpecificCulture("en-GB"));
      System.Console.WriteLine("d1:" + d1.ToString());
      System.Console.WriteLine("d2:" + d2.ToString());
      System.Console.WriteLine("d3:" + d3.ToString());
      System.Console.ReadKey();
    }
