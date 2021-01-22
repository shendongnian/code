    public class Country
    {
      public string Name { get; set; }
      public IList<City> Cities { get; set; }
    
      public Country()
      {
        Cities = new List<City>();
      }
    }
    
    public class City { public string Name { get; set; } }
