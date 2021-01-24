    public class Continent {
      
      [PrimaryKey]
      public int Id { get; set; }
    
      public string Name { get; set; }
    
      public List<Country> Countries { get; set; }
    
    }
    
    public class Country {
      
      [PrimaryKey]
      public int Id { get; set; }
    
      public string Name { get; set; }
      
      [ForeignKey(typeof(Continent))]
      public int ContinentId { get; set; }
    
      public List<City > Cities { get; set; }
    
    }
       public class City {
         
          [PrimaryKey]
          public int Id { get; set; }
     
          public string Name { get; set; }
    
    
          [ForeignKey(typeof(Country))]
          public int CountryId { get; set; }
      }
