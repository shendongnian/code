    public class IPAddressPatternConverter : IConvertFrom
    {
        public IPAddressPatternConverter()
        {}
        public Boolean CanConvertFrom(Type sourceType)
        {
            return typeof(String) == sourceType;
        }
        
        public Object ConvertFrom(Object source)
        {
            String pattern = (String)source;
            PatternString patternString = new PatternString(pattern);
            String value = patternString.Format();
            return IPAddress.Parse(value);
        }
    }
