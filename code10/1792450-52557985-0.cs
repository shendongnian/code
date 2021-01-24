    public class User
    {
        [JsonProperty("userFirstName")] public string Name { get; set; }
    
        [JsonProperty("userLastName")] public string LastName { get; set; }
    
        [JsonExtensionData] Dictionary<string, JToken> _userDefined;
        public Dictionary<string, string> UserDefined => _userDefined.ToDictionary(x => x.Key.Replace("userDefined-", string.Empty), x => x.Value.ToString());
    }
