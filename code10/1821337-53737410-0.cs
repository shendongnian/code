    [WrapperAttribute(Key = "primaryContact")]
    public class PrimaryContact
    {
        [WrapperAttribute(Key= "prefixTitle")]
        public string PrefixTitle { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }
    }
    public class WrapperAttribute : Attribute
    {
        public string Key { get; set; }
    }
    public class WrapperSerializer : JsonConverter<PrimaryContact>
    {
        public override void WriteJson(JsonWriter writer, PrimaryContact value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            JObject root = new JObject();
            foreach (var property in type.GetAllProperties())
            {
                if (property.HasAttribute<WrapperAttribute>())
                {
                    JProperty wrappedProperty = new JProperty(property.GetAttribute<WrapperAttribute>().Key);
                    JObject wrappedChild = new JObject();
                    wrappedProperty.Value = wrappedChild;
                    
                    JProperty wrappedChildProperty = new JProperty("value");
                    wrappedChildProperty.Value = JToken.FromObject(property.GetValue(value));
                    wrappedChild.Add(wrappedChildProperty);
                    root.Add(wrappedProperty);
                }
                else
                {
                    var childProperty = new JProperty(property.Name);
                    childProperty.Value = JToken.FromObject(property.GetValue(value));
                    root.Add(childProperty);
                }
            }
            if (type.HasAttribute<WrapperAttribute>())
            {
                JObject wrappedRoot = new JObject();
                var wrappedProperty = new JProperty(type.GetAttribute<WrapperAttribute>().Key);
                wrappedProperty.Value = root;
                wrappedRoot.Add(wrappedProperty);
                wrappedRoot.WriteTo(writer);
            }
            else
            {
                root.WriteTo(writer);
            }
        }
        public override PrimaryContact ReadJson(JsonReader reader, Type objectType, PrimaryContact existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
