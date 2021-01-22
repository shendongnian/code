    public class Country : ICountry
    {
        private readonly ICountryInfo _countryInfo;
        public Country(ICountryInfo countryInfo)
        {
            _countryInfo = countryInfo;
        }
        public ICountryInfo Info
        {
            get { return _countryInfo; }
        }
    }
    public class CountryInfo : ICountryInfo
    {
        public int Population { get; set; }
        public string Note { get; set;}
    }
