    public class DataType
    {
        private readonly string value;
        private static readonly Dictionary<string, DataType> predefinedValues;
    
        public static readonly DataType Json = new DataType("json");
        public static readonly DataType Xml = new DataType("xml");
        public static readonly DataType Text = new DataType("text");
        public static readonly DataType Html = new DataType("html");
        public static readonly DataType Binary = new DataType("binary");
    
        static DataType()
        {
            predefinedValues = new Dictionary<string, DataType>();
            predefinedValues.Add(Json.Value, Json);
            predefinedValues.Add(Xml.Value, Xml);
            predefinedValues.Add(Text.Value, Text);
            predefinedValues.Add(Html.Value, Html);
            predefinedValues.Add(Binary.Value, Binary);
        }
    
        private DataType(string value)
        {
            this.value = value;
        }
    
        public static DataType Parse(string value)
        {
            var exception = new FormatException($"Invalid value for type {nameof(DataType)}");
            if (string.IsNullOrEmpty(value))
                throw exception;
    
            string key = value.ToLower();
            if (!predefinedValues.ContainsKey(key))
                throw exception;
    
            return predefinedValues[key];
        }
    
        public string Value
        {
            get { return value; }
        }
    }
