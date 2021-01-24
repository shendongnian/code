    public interface ICountry
    {
        int Id { get; }
        string Name { get; }
        // .. and so on.
    }
    public class Finland : ICountry
    {
        public string Name { get; private set; } = "Finland";
        public int Id { get; private set; } = 7;
    }
    public class CountryRegistry
    {
        private Dictionary<string, ICountry> countryMap;
        public CountryRegistry()
        {
            this.countryMap = new Dictionary<string, ICountry>();
            InitCountries();
        }
        public ICountry FindByName( string searchName )
        {
            ICountry result;
            if( this.countryMap.TryGetValue( searchName, out result ) )
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        private void InitCountries()
        {
            AddCountryToMap( new Finland() );
            // .. and so on
        }
        private void AddCountryToMap( ICountry country )
        {
            this.countryMap.Add( country.Name, country );
        }
    }
