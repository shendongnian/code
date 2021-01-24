    public class StringTruncatingPropertyResolver : DefaultContractResolver
    {
        public int DefaultMaxLength { get; private set; }
        public StringTruncatingPropertyResolver(int defaultMaxLength)
        {
            DefaultMaxLength = defaultMaxLength;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // Apply a StringTruncatingValueProvider to all string properties
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                int maxLength = DefaultMaxLength;
                var attr = prop.AttributeProvider
                               .GetAttributes(true)
                               .OfType<MaxLengthAttribute>()
                               .FirstOrDefault();
                if (attr != null)
                {
                    maxLength = attr.Length;
                }
                prop.ValueProvider = new StringTruncatingValueProvider(prop.ValueProvider, maxLength);
            }
            return props;
        }
        class StringTruncatingValueProvider : IValueProvider
        {
            private IValueProvider InnerValueProvider { get; set; }
            private int MaxLength { get; set; }
            public StringTruncatingValueProvider(IValueProvider innerValueProvider, int maxLength)
            {
                InnerValueProvider = innerValueProvider;
                MaxLength = maxLength;
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the string;
            // the return value is a string that gets written to the JSON.
            public object GetValue(object target)
            {
                return InnerValueProvider.GetValue(target);
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the string value read from the JSON;
            // target is the object on which to set the (possibly truncated) value.
            public void SetValue(object target, object value)
            {
                string s = (string)value;
                if (s != null && s.Length > MaxLength)
                {
                    s = s.Substring(0, MaxLength);
                }
                InnerValueProvider.SetValue(target, s);
            }
        }
    }
