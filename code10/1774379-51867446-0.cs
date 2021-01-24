    public class Wrapper<T> 
    {
        // No need for [JsonProperty("data")] here
        public T[] Data { get; set; }
        public bool Success { get; set; }
    }
