    public class DataTypeResolver : DefaultContractResolver
    {
        private Dictionary<DataType, JsonConverter> ConvertersByDataType { get; set; }
        public DataTypeResolver()
        {
            // Adjust this list to match your actual data types and converters
            ConvertersByDataType = new Dictionary<DataType, JsonConverter>
            {
                { DataType.PostalCode, new PostalCodeConverter() },
                { DataType.PhoneNumber, new PhoneNumberConverter() },
            };
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            var att = prop.AttributeProvider.GetAttributes(true).OfType<DataTypeAttribute>().FirstOrDefault();
            if (att != null)
            {
                JsonConverter converter;
                if (ConvertersByDataType.TryGetValue(att.DataType, out converter))
                {
                    prop.Converter = converter;
                }
            }
            return prop;
        }
    }
