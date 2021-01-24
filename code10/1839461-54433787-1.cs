        public class ToStringJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
    
                var isTypeImplementStringToTypeConverter = objectType.GetInterfaces().Any(x =>
                    x == typeof(ITypeToStringConverter) ||
                    (x.IsGenericType &&
                    x.GetGenericTypeDefinition() == typeof(IStringToTypeConverter<>)));
    
                return isTypeImplementStringToTypeConverter;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString());
            }
    
            public override bool CanRead
            {
                get { return true; }
            }
    
            public override bool CanWrite
            {
                get { return true; }
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // Load the JSON for the Result into a JObject
    
                var stringValue = reader.Value.ToString();
    
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    var jObject = JObject.Load(reader);
                    stringValue = jObject.ToString();
    
                }
    
                MethodInfo parse = objectType.GetMethod("ConvertToType");
                if (parse != null)
                {
                    var destinationObject = Activator.CreateInstance(objectType,stringValue);
                    return parse.Invoke(destinationObject, new object[] { stringValue });
                }
    
                throw new JsonException($"The {objectType.Name} type does not have a public ConvertToType(string) method.");
            }
        }
