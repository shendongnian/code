    public class Root
    {
        [JsonProperty("d")]
        public JObject Data { get; set; }
    }
    JsonConvert.DeserializeObject<Root>(json).Data.ToObject<TResult>();
