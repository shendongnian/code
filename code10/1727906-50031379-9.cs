    public class DataConverter : JsonConverter {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jObject = JObject.Load(reader);
            var data = new Data();
            if (jObject.TryGetValue("Description", out JToken jDescription)) {
                data.Description = jDescription.Value<string>();
            }
            if (jObject.TryGetValue("Target", out JToken jTarget)) {
                data.Target = ToTarget(jTarget, serializer);
            }
            if (jObject.TryGetValue("Category", out JToken jCategory)) {
                data.Category = jCategory.Value<int>();
            }
            return req;
        }
        private static ICollection<int> ToTarget( JToken jTarget, JsonSerializer serializer ) {
            int defaultValue = -1;
            var target = new List<int>();
            var collection = jTarget.Value<string>().Split(',');
            foreach (string str in collection)
                if (int.TryParse(str, out int number))
                    target.Add(number);
                else
                    target.Add(defaultValue);
            return target;
        }
        public override bool CanConvert(Type objectType) => objectType == typeof(Data);
    }
