    public class MyCustomJsonConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jObj = new JObject();
            if (value != null)
            {
                var dict = JObject.Parse(value as string)["allItems"].ToObject<Dictionary<string, Item>>();
                foreach (var item in dict)
                {
                    JObject jObject = new JObject();
                    if (item.Value.IsSelected == false && item.Value.SelectionInfo.Count == 0)
                    {
                        jObj.Add(new JProperty(item.Key, new JObject()));
                    }
                    else
                    {
                        jObj.Add(new JProperty(item.Key, JObject.FromObject(item.Value)));
                    }
                }
            }
            JObject jMainObject = new JObject();
            jMainObject.Add(new JProperty("allItems", jObj));
            jMainObject.WriteTo(writer);
        }
    }
    
