    public class Country
    {
        public int ID { get; }
        public string NameOfCountry { get; }
        public string Abbreviation { get; }
        public string FlagLocation { get; }
        public Country(int id, string nameOfCountry, string abbreviation, string flagLocation)
        {
            ID = id;
            NameOfCountry = nameOfCountry;
            Abbreviation = abbreviation;
            FlagLocation = flagLocation;
        }        
    }
