    [DataContract]
    public class Foo<T> where T : class
    {
        [JsonConverter(typeof(SingleOrMany))]
        public List<T> Content { get; set; }
    }
    public class SingleOrMany : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
