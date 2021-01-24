    [Serializable]
    public class CountryInfoModel 
    {
        public int BwinId { get; set; }
        public string TranslatedName { get; set; }
        public string TwoLetterCode { get; set; }
        public bool LoginAllowed { get; set; }
        public bool RegistrationAllowed { get; set; }
        [JsonConverter(typeof(TranslationsToDictionaryObjectConverter))]
        public Dictionary<string, string> Translations { get; set; }
    }
