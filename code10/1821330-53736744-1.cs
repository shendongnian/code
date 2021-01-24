    public class PrimaryContact
    {
        [JsonConverter(typeof(NestedValueConverter<string>))]
        public string PrefixTitle { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }
    }
