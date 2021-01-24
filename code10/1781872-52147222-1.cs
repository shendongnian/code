    using Newtonsoft.Json;
    [JsonObject]
    public class UserData {
        [JsonProperty] //Add a JSON property "Username" which is a string
        public string Username { get; set; }
        //IEnumerable types are converted to/from arrays automatically by Newtonsoft        
        [JsonProperty("Options")] //Set the name in JSON file to "Options"
        public Dictionary<string, string> Preferences { get; set; }
        [JsonIgnore] //Excludes this property from the JSON output
        public bool SaveRequired { get; set; } //Set true when a change is made, set false when saved
    }
