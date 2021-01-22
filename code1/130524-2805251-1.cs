    public class Country : ICountry {
      // this property cannot be declared as CountryInfo
      public ICountry.ICountryInfo Info { get; set; }
      
      public class CountryInfo : ICountry.ICountryInfo {
        public string Note { get; set; }
        public int Population { get; set; }
      }
    }
