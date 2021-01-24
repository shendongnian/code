    public class PropertyValue
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public float FloatValue { get; set; }
        public List<ProductPropertyValue> ListValue { get; set; }
    
        public PropertyValue()
        {
            IntValue = int.MaxValue;
            FloatValue = float.MaxValue;
        }
    
        [JsonIgnore]
        public string Value
        {
            get
            {
                if (IntValue != int.MaxValue)
                {
                    return IntValue.ToString();
                }
    
                if (FloatValue != float.MaxValue)
                {
                    return FloatValue.ToString();
                }
    
                return StringValue;
            }
        }
    }
