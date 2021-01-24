    class User{
        [JsonProperty("result")]
        public Result result { get; set; }
    }
    
    class Result{
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
