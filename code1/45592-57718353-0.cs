    public class Test
    {
        [XmlIgnore]
        public Nullable<int> NullableNumber = 7;
        [XmlElement("NullableNumber")]
        public int NullableNumberValue
        {
            get { return NullableNumber.Value; }
            set { NullableNumber = value; }
        }
        public bool ShouldSerializeNullableNumberValue()
        {
            return NullableNumber.HasValue;
        }
        [XmlElement]
        public int Number = 5;
    }
