    /// <summary>
    /// Json deserialization for inheritance structure with discriminator
    /// </summary>
    public class InheritanceConverter : JsonConverter
    {
        /// <summary>
        /// Default name for the discriminator property
        /// </summary>
        private string _discriminator { get; set; } = "discriminator";
        public InheritanceConverter()
        {
        }
        /// <summary>
        /// Discriminator name to map between types
        /// </summary>
        /// <param name="discriminator">The discriminator property name. The defualt value is 'discriminator'</param>
        public InheritanceConverter(string discriminator)
        {
            if (!string.IsNullOrWhiteSpace(discriminator))
                _discriminator = discriminator;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //Check null
            if (reader.TokenType == JsonToken.Null) return null;
            //Parse json
            var jDerivedObject = JObject.Load(reader);
            //Get discriminator
            var discriminator = jDerivedObject.Value<string>(_discriminator);
            if (string.IsNullOrWhiteSpace(discriminator))
                throw new Exception("Invalid discriminator value");
            //Get the type
            var derivedType = GetSubType(discriminator, objectType);
            //Create a new instance of the target type
            var derivedObject = Activator.CreateInstance(derivedType);
            //Populate the derived object
            serializer.Populate(jDerivedObject.CreateReader(), derivedObject);
            return derivedObject;
        }
        //TODO:- validate based on the base and sub-types via the KnownTypeAttributes
        public override bool CanConvert(Type objectType) => true;
        //Not required
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        //Not required
        public override bool CanWrite => false;
        #region Methods
        /// <summary>
        /// Get sub-type via KnownTypeAttributes
        /// </summary>
        /// <param name="derivedTypeName">The target type name which corosponds to the discriminator</param>
        private Type GetSubType(string derivedTypeName, Type baseType)
        {
            var knownTypes = baseType.GetCustomAttributes(false).Where(ca => ca.GetType().Name == "KnownTypeAttribute").ToList();
            if (knownTypes == null || knownTypes.Count == 0)
                throw new Exception(
                    string.Format("Couldn't find any KnownAttributes over the base {0}. Please define at least one KnownTypeAttribute to determine the sub-type", baseType.Name));
            foreach (dynamic type in knownTypes)
            {
                if (type.Type != null && type.Type.Name.ToLower() == derivedTypeName.ToLower())
                    return type.Type;
            }
            throw new Exception(string.Format("Discriminator '{0}' doesn't match any of the defined sub-types via KnownTypeAttributes", derivedTypeName));
        }
        #endregion
    }
