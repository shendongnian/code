    public class Action
    {
       [JsonProperty(PropertyName = "actid")]
       public string ActId { get; set; }
       public string Type { get; set; }
       public string Amount { get; set; }
       public string Timestamp { get; set; }
    }
