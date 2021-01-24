    public class ObjectDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, object>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenType = reader.SkipComments().TokenType;
            if (tokenType == JsonToken.Null)
                return null;
            var tempDictionary = new Dictionary<string, object>();
            var old = reader.DateParseHandling;
            try
            {
                // Disable recognition of date strings
                reader.DateParseHandling = DateParseHandling.None;
                serializer.Populate(reader, tempDictionary);
            }
            finally
            {
                reader.DateParseHandling = old;
            }
            var dictionary = existingValue as IDictionary<string, object> ?? (IDictionary<string, object>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            foreach (var pair in tempDictionary)
                dictionary.Add(pair.Key, pair.Value.ToObject());
            return dictionary;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader SkipComments(this JsonReader reader)
        {
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
        public static object ToObject(this object obj)
        {
            return ToObject(obj as JToken) ?? obj;
        }
        public static object ToObject(this JToken token)
        {
			// Adapts the logic from https://stackoverflow.com/a/19140420/3744182) 
			// to https://stackoverflow.com/q/5546142/3744182
			// By [Brian Rogers](https://stackoverflow.com/users/10263/brian-rogers)
			
            if (token == null)
                return null;
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.Object:
                    return token.Children<JProperty>()
                                .ToDictionary(prop => prop.Name,
                                              prop => ToObject(prop.Value));
                case JTokenType.Array:
                    {
                        var list = token.Select(t => ToObject(t)).ToList();
                        if (list.All(i => i is long))
                            return list.Cast<long>().ToArray();
                        else if (list.All(i => i is string))
                            return list.Cast<string>().ToArray();
                        else return list.ToArray();
                    }
                default:
                    return ((JValue)token).Value;
            }
        }
    }
