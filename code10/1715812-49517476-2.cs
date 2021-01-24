        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == Newtonsoft.Json.JsonToken.Null)
                return null;
            JObject obj = JObject.Load(reader);
            var customObject = JsonConvert.DeserializeObject<T>(obj.ToString(), new JsonSerializerSettings 
                            {
                                ContractResolver = new CustomContractResolver()
                            });
            customObject.Original = obj.ToString();
                return customObject;
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
    //This will remove our declared Converter
    public class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter (Type objectType)
        {
            return null;
        }
    }
