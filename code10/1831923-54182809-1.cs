      public class JsonPathConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var properties = value.GetType().GetRuntimeProperties().Where(p => p.CanRead && p.CanWrite);
            JObject main = new JObject();
            foreach (PropertyInfo prop in properties)
            {
                JsonPropertyAttribute att = prop.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();
                string jsonPath = att != null ? att.PropertyName : prop.Name;
                if (serializer.ContractResolver is DefaultContractResolver resolver)
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);
                var nesting = jsonPath.Split('.');
                JObject lastLevel = main;
                for (int i = 0; i < nesting.Length; ++i)
                {
                    if (i == (nesting.Length - 1))
                    {
                        lastLevel[nesting[i]] = new JValue(prop.GetValue(value));
                    }
                    else
                    {
                        if (lastLevel[nesting[i]] == null)
                            lastLevel[nesting[i]] = new JObject();
                        lastLevel = (JObject) lastLevel[nesting[i]];
                    }
                }
            }
            serializer.Serialize(writer, main);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jo = JToken.Load(reader);
            object targetObj = Activator.CreateInstance(objectType);
            foreach (PropertyInfo prop in objectType.GetRuntimeProperties().Where(p => p.CanRead && p.CanWrite))
            {
                var attributes = prop.GetCustomAttributes(true).ToArray();
                JsonIgnoreAttribute ignoreAttribute = attributes.OfType<JsonIgnoreAttribute>().FirstOrDefault();
                if (ignoreAttribute != null)
                    continue;
                JsonPropertyAttribute att = attributes.OfType<JsonPropertyAttribute>().FirstOrDefault();
                string jsonPath = att != null ? att.PropertyName : prop.Name;
                if (serializer.ContractResolver is DefaultContractResolver resolver)
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);
                if (!Regex.IsMatch(jsonPath, @"^[a-zA-Z0-9_.-]+$"))
                    throw new InvalidOperationException(
                        $"JProperties of JsonPathConverter can have only letters, numbers, underscores, hyphens and dots but name was ${jsonPath}."); // Array operations not permitted
                JToken token = jo.SelectToken(jsonPath);
                if (token != null && token.Type != JTokenType.Null)
                {
                    object value;
                    var jsonConverterAttr = attributes.OfType<JsonConverterAttribute>().FirstOrDefault();
                    if (jsonConverterAttr == null)
                    {
                        value = token.ToObject(prop.PropertyType, serializer);
                    }
                    else
                    {
                        var converter = (JsonConverter) Activator.CreateInstance(jsonConverterAttr.ConverterType,
                            jsonConverterAttr.ConverterParameters);
                        var r = token.CreateReader();
                        r.Read();
                        value = converter.ReadJson(r, prop.PropertyType, prop.GetValue(targetObj),
                            new JsonSerializer());
                    }
                    prop.SetValue(targetObj, value, null);
                }
            }
            return targetObj;
        }
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return false;
        }
    }
