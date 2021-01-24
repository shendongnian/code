    internal class ItemConverter : JsonConverter
    {
        private Type currentType;
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(Item).IsAssignableFrom(objectType) || objectType == typeof(Result);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            if (item["UseCustomItems"] != null)
            {
                // save the type for later.
                switch (item["UseCustomItems"].Value<bool>())
                {
                    case true:
                        currentType = typeof(ResultA);
                        return item.ToObject<ResultA>(); // return result as customitems result
                    case false:
                        currentType = typeof(ResultB);
                        return item.ToObject<ResultB>(); // return result as allitems result
                }
                return item.ToObject<Result>();
            }
    
            // use the last type you read to serialise.
            return item.ToObject(currentType);
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
