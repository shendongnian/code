    public class Country
    {
        public int ID { get; private set; }
        public string NameOfCountry { get; private set; }
        public string Abbreviation { get; private set; }
        public string FlagLocation { get; private set; }
        public Country(int id, string nameOfCountry, string abbreviation, string flagLocation)
        {
            ID = id;
            NameOfCountry = nameOfCountry;
            Abbreviation = abbreviation;
            FlagLocation = flagLocation;
        }        
    }
