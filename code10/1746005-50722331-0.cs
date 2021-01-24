    public class ListWithIndexConverter<T> : JsonConverter where T : IIndexedObject
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type != JTokenType.Array)
            {
                return new List<T>();
            }
            var returnList = new List<T>();
            for(var i=0; i < token.Count(); i++)
            {
                var returnObject = token[i].ToObject<T>();
                returnObject.Index = i;
                returnList.Add(returnObject);
            }
            return returnList;
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public interface IIndexedObject
    {
        int Index { get; set; }
    }
    public class SomeObject
    {
        [JsonConverter(typeof(ListWithIndexConverter<Host>))]
        public List<Host> Hosts { get; set; }
    }
    public class Host : IIndexedObject
    {
         //some properties
    }
