    [JsonConverter(typeof(CustomQueryConverter))]
    public class Query
    {
        public Query(int[] ids)
        {
            IDs = ids;
        }
        public int[] IDs { get; }
    }
    public class CustomQueryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Query);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var array = JArray.Load(reader);
            int[] items = array?.Select(jv => (int)jv).ToArray();
            return new Query(items);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var query = value as Query;
            serializer.Serialize(writer, query.IDs);
        }
    }
