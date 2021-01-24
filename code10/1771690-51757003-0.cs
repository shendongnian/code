    public class RootObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonIgnore]
        public string Settings
        {
            get { return SettingsJToken.ToString(Formatting.None); }
            set { SettingsJToken = value != null ? JToken.Parse(value) : JValue.CreateNull(); }
        }
        [JsonProperty("settings")]
        private JToken SettingsJToken { get; set; }
    }
