    public partial class SleepEntry
    {
        [JsonProperty("Entry_number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long EntryNumber { get; set; }
        [JsonProperty("Entry_date")]
        public DateTimeOffset EntryDate { get; set; }
        [JsonProperty("Customer_number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CustomerNumber { get; set; }
        [JsonProperty("Entry_value")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long EntryValue { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
    }
    public partial class SleepEntry
    {
        public static SleepEntry[] FromJson(string json) => JsonConvert.DeserializeObject<SleepEntry[]>(json, QuickType.Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this SleepEntry[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }
        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
