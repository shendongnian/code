    class CustomObjectConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            
            RootObj result = new RootObj();
            result.category = array[0].ToObject<Category>();
            array.RemoveAt(0);
            result.details = array.ToObject<List<Detail>>();
            return result;
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(RootObj));
        }
    }
