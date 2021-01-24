    public class RootObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Settings
        {
            get { return SettingsToken != null ? SettingsToken.ToString(Formatting.None) : null; }
            set { SettingsToken = value != null ? JToken.Parse(value) : JValue.CreateNull(); }
        }
        [JsonProperty("settings")]
        private JToken SettingsToken { get; set; }
    }
