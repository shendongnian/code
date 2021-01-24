    namespace TelegramBot
    {
        class Angebot
        {
            [JsonProperty("id")]
            public int id { get; set; }
    
            [JsonProperty("name")]
            public string name { get; set; }
    
            [JsonProperty("category")]
            public string category { get; set; }
    
            [JsonProperty("prices")]
            public Prices Prices { get; set; }
    
            [JsonProperty("notes")]
            public IList<string> notes { get; set; }
        }
    }
    namespace TelegramBot
    {
        class Prices
        {
            [JsonProperty("students")]
            public float? students { get; set; }
    
            [JsonProperty("employees")]
            public float? employees { get; set; }
    
            [JsonProperty("pupils")]
            public float? pupils { get; set; }
    
            [JsonProperty("others")]
            public float? others { get; set; }
   
        }
    }
