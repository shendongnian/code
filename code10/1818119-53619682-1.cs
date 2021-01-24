    public class MyModel
        {
            [JsonConverter(typeof(CustomJsonConverter))]
            public Dictionary<string, List<string>> data { get; set; }
        }
