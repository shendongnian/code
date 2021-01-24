    class Program
    {
        static void Main(string[] args)
        {
            var valueInt = new ValueInteger
            {
                ValueName = "mycounter",
                Value = 7,
                TimeStamp = 1010101010
            };
            var settings = new JsonSerializerSettings { Converters = new JsonConverter[] { new DynamicNameConverter() } };
            var result = JsonConvert.SerializeObject(valueInt, settings);
            Console.WriteLine(result);
            Console.Read();
        }
    }
    public class ValueInteger
    {
        [JsonIgnore]
        public string ValueName { get; set; }
        [JsonDynamicName(nameof(ValueName))]
        public int Value { get; set; }
        [JsonProperty("timestamp")]
        public UInt64 TimeStamp { get; set; }
    }
