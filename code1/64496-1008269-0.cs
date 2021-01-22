    public class Country
    {
        public static readonly Country UnitedKingdom = new Country("UK");
        public static readonly Country UnitedStates = new Country("US");
        public static readonly Country France = new Country("FR");
        public static readonly Country Protugal = new Country("PT");
        private Country(string shortName)
        {
            ShortName = shortName;
        }
        public string ShortName { get; private set; }
    }
