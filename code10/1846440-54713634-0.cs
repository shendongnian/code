    public class ArrayJsonConverter<T> : JsonConverter<List<T>>
    {
        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var jObj = JObject.Load(reader);
                var obj = jObj.ToObject<T>();
                var lst = new List<T>();
                lst.Add(obj);
                return lst;
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                var jArray = JArray.Load(reader);
                return jArray.ToObject<IEnumerable<T>>().ToList();
            }
            throw new InvalidOperationException();
        }
        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
