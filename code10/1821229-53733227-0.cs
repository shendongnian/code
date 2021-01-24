     public class SkinTypes
    {
        private readonly string _value;
        public SkinTypes(string value)
        {
            _value = value;
        }
        public static implicit operator string(SkinTypes d)
        {
            return d._value;
        }
        public static implicit operator SkinTypes(string d)
        {
            return  new SkinTypes(d);
        }
      
        public override string ToString()
        {
            return _value;
        }
        public const string StringValue = "StringValue";
        public const string Color = "Color";
    }
