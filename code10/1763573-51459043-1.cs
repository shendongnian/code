    class DynamicNameConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // Only use this converter for classes that contain properties with an JsonDynamicNameAttribute.
            return objectType.IsClass && objectType.GetProperties().Any(prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(JsonDynamicNameAttribute)));
        }
        public override bool CanRead => false;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // We do not support deserialization.
            throw new NotImplementedException();
        }
        public override bool CanWrite => true;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(value);
            if (token.Type != JTokenType.Object)
            {
                // We should never reach this point because CanConvert() only allows objects with JsonPropertyDynamicNameAttribute to pass through.
                throw new Exception("Token to be serialized was unexpectedly not an object.");
            }
            JObject o = (JObject)token;
            var propertiesWithDynamicNameAttribute = value.GetType().GetProperties().Where(
                prop => prop.CustomAttributes.Any(attr => attr.AttributeType == typeof(JsonDynamicNameAttribute))
            );
            foreach (var property in propertiesWithDynamicNameAttribute)
            {
                var dynamicAttributeData = property.CustomAttributes.FirstOrDefault(attr => attr.AttributeType == typeof(JsonDynamicNameAttribute));
                // Determine what we should rename the property from and to.
                var currentName = property.Name;
                var propertyNameContainingNewName = (string)dynamicAttributeData.ConstructorArguments[0].Value;
                var newName = (string)value.GetType().GetProperty(propertyNameContainingNewName).GetValue(value);
                // Perform the renaming in the JSON object.
                var currentJsonPropertyValue = o[currentName];
                var newJsonProperty = new JProperty(newName, currentJsonPropertyValue);
                currentJsonPropertyValue.Parent.Replace(newJsonProperty);
            }
            token.WriteTo(writer);
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class JsonDynamicNameAttribute : Attribute
    {
        public string ObjectPropertyName { get; }
        public JsonDynamicNameAttribute(string objectPropertyName)
        {
            ObjectPropertyName = objectPropertyName;
        }
    }
