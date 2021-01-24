    public class Token
        {
            [JsonProperty("Access Token")]
            public string AccessToken { get; set; }
    
            // In this property attribute is not requied
            [JsonProperty("Alias")]
            public string Alias { get; set; }
        } 
 
