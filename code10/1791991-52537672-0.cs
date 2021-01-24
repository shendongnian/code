    public class TypePropertyConverter : JsonConverter
    {
        /// <summary>
        /// During write, we have to return CanConvert = false to be able to user FromObject internally w/o "self referencing loop" errors.
        /// </summary>
        private bool _isInWrite = false;
        public override bool CanWrite => !_isInWrite;
        private static Dictionary<string, Type> _allItemTypes;
        public static Dictionary<string, Type> AllItemTypes => _allItemTypes ?? (_allItemTypes = GetAllItemTypes());
        /// <summary>
        /// Read all types with JsonType or BsonDiscriminator attribute from current assembly.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Type> GetAllItemTypes()
        {
            var allTypesFromApiAndCore = typeof(TypePropertyConverter)
                .Assembly
                .GetTypes()
                .Concat(typeof(OrdersCoreRegistry)
                    .Assembly
                    .GetTypes());
            var dict = new Dictionary<string, Type>();
            foreach (var type in allTypesFromApiAndCore)
            {
                if (type.GetCustomAttributes(false).FirstOrDefault(a => a is JsonTypeAttribute) is JsonTypeAttribute attr)
                {
                    dict.Add(attr.TypeName, type);
                }
                else if (type.GetCustomAttributes(false).FirstOrDefault(a => a is BsonDiscriminatorAttribute) is BsonDiscriminatorAttribute bda)
                {
                    dict.Add(bda.Discriminator, type);
                }
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            _isInWrite = true;
            try
            {
                var type = value.GetType();
                var typeKey = AllItemTypes.First(kv => kv.Value == type).Key;
                var jObj = JObject.FromObject(value, serializer);
                jObj.AddFirst(new JProperty("type", typeKey));
                jObj.WriteTo(writer);
            }
            finally
            {
                _isInWrite = false;
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            // we need to read and remove the "type" property first
            var obj = JObject.Load(reader);
            var typeKey = obj["type"];
            if (typeKey == null)
            {
                throw new InvalidOperationException("Cannot deserialize object w/o 'type' property.");
            }
            obj.Remove("type");
            // create object
            if (!AllItemTypes.TryGetValue(typeKey.Value<string>(), out var type))
            {
                throw new InvalidOperationException($"No type registered for key '{typeKey}'. Annotate class with JsonType attribute.");
            }
            var contract = serializer.ContractResolver.ResolveContract(type);
            var value = contract.DefaultCreator();
            if (value == null)
            {
                throw new JsonSerializationException("No object created.");
            }
            using (var subReader = obj.CreateReader())
            {
                serializer.Populate(subReader, value);
            }
            return value;
        }
        public override bool CanConvert(Type objectType)
        {
            return AllItemTypes.Any(t => t.Value == objectType);
        }
    }
