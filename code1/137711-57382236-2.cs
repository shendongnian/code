    public class SafeEnumConverter : StringEnumConverter
    {
        private readonly int _defaultValue;
        public SafeEnumConverter()
        {
            // if you've been careful to *always* create enums with `0` reserved
            // as an unknown/default value (which you should), you could use 0 here. 
            _defaultValue = -1;
        }
        public SafeEnumConverter(int defaultValue)
        {
            _defaultValue = defaultValue;
        }
        /// <summary>
        /// Reads the provided JSON and attempts to convert using StringEnumConverter. If that fails set the value to the default value.
        /// </summary>
        /// <returns>The deserialized value of the enum if it exists or the default value if it does not.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch
            {
                return Enum.Parse(objectType, $"{_defaultValue}");
            }
        }
        public override bool CanConvert(Type objectType)
        {
            return base.CanConvert(objectType) && objectType.GetTypeInfo().IsEnum;
        }
    }
