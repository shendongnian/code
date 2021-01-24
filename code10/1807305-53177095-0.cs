    public class ClassWithItemsConverter<T> : JsonConverter where T : class, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            JProperty items = jo.Property("items");
            if (items != null && items.Value.Type == JTokenType.Array)
            {
                foreach (JObject item in items.Value.Children<JObject>())
                {
                    jo.Add((string)item["name"], item["value"]);
                }
                items.Remove();
            }
            T result = new T();
            serializer.Populate(jo.CreateReader(), result);
            return result;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
