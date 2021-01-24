    public class SkinType:StringType<SkinType>
    {
        public SkinType(string value)
        {
            Value = value;
        }
        public SkinType()
        {
           
        }
        public static implicit operator string(SkinType d)
        {
            return d.Value;
        }
        public static implicit operator SkinType(string d)
        {
            return  new SkinType(d);
        }
        public const string StringValue = nameof(StringValue);
        public const string Color = nameof(Color);
    }
