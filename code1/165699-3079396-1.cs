    class HouseInfo
    {
       public string Name;
       public int HouseNumber;
       public HouseInfo(string Name, int HouseNumber)
       {
          this.Name = Name;
          this.HouseNumber = HouseNumber;
       }
    }
    class StreetInfo
    {
       public string Street;
       public int FirstHouseNumber;
       public int LastHouseNumber;
       public StreetInfo(string Street, int FirstHouseNumber, int LastHouseNumber)
       {
          this.Street = Street;
          this.FirstHouseNumber = FirstHouseNumber;
          this.LastHouseNumber = LastHouseNumber;
       }
    }
    static void Main(string[] args)
    {
       HouseInfo[] houses = new HouseInfo[] {
          new HouseInfo("Chris", 123),
          new HouseInfo("Ben", 456),
          new HouseInfo("Joe", 789) };
       StreetInfo[] streets = new StreetInfo[] {
          new StreetInfo("Broadway", 100, 500),
          new StreetInfo("Main", 501, 1000)};
       var funcquery = from name in houses
                       from street in streets
                       where name.HouseNumber >= street.FirstHouseNumber && name.HouseNumber <= street.LastHouseNumber
                       select new { Name = name.Name, Number = name.HouseNumber, Street = street.Street };
       var results = funcquery.ToArray();
       for (int i = 0; i < results.Length; i++)
       {
          Console.WriteLine("{0} {1} {2}", results[i].Name, results[i].Number, results[i].Street);
       }
    }
