    public class Rootobject
    {
        [JsonProperty("geonames")]
        public Geoname[] Geonames { get; set; }
    }
    public class Geoname
    {
        [JsonProperty("continent")]
        public string Continent { get; set; }
        [JsonProperty("capital")]
        public string Capital { get; set; }
        [JsonProperty("languages")]
        public string Languages { get; set; }
        [JsonProperty("geonameId")]
        public int GeonameId { get; set; }
        [JsonProperty("south")]
        public float South { get; set; }
        [JsonProperty("isoAlpha3")]
        public string IsoAlpha3 { get; set; }
        [JsonProperty("north")]
        public float North { get; set; }
        [JsonProperty("fipsCode")]
        public string FipsCode { get; set; }
        [JsonProperty("population")]
        public string Population { get; set; }
        [JsonProperty("east")]
        public float East { get; set; }
        [JsonProperty("isoNumeric")]
        public string IsoNumeric { get; set; }
        [JsonProperty("areaInSqKm")]
        public string AreaInSqKm { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("west")]
        public float West { get; set; }
        [JsonProperty("countryName")]
        public string CountryName { get; set; }
        [JsonProperty("continentName")]
        public string ContinentName { get; set; }
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }
    }
