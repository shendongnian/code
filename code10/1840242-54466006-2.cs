    public class CountryMedalTally {
        public string Country { get; set; }
        public string[] Medals { get; set; }
        public int MedalCount { get; set; }
    }
    public class Winner {
        public List<string> Country { get; set; }
        public int MedalCount { get; set; }
    }
    List<CountryMedalTally> AllMedals;
