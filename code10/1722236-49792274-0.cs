    public class Response<TValue>
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    
        [JsonProperty("value")]
        private string ValueString { get; set; }
    
        public TValue Value { get; set; }
    
        [OnDeserialized]
        internal void DeserializeValue(StreamingContext context)
        {
            Value = JsonConvert.DeserializeObject<TValue>(ValueString);
        }
    }
