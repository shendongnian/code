    public class InputData {
        [JsonProperty("method")]
        public string method { get; set; }
        [JsonProperty("hashcode")]
        public string hashcode { get; set; }
        [JsonProperty("accountId")]
        public string accountId { get; set; }
    }
    public class BaseInput {
        [JsonProperty("Input_data")]
        public InputData Input_data { get; set; }
    }
