    public class UserDetails
    {
        public static string PersistedRateCountry { get; set; }
        public static string PersistedRateWeek { get; set; }
        public static string RateCountry
        {
            get { return string.IsNullOrEmpty(rateType) ? "" : PersistedRateCountry; }
            set { PersistedRateCountry = value; }
        }
        public static string RateWeek
        {
            get { return string.IsNullOrEmpty(rateType) ? "" : PersistedRateWeek; }
            set { PersistedRateWeek= value; }
        }
        public static string RateWeek { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
