    public class SomeObject
    {
        public string SomeTypeName
        {
            get { return SomeType.AssemblyQualifiedName; }
            set
            {
                var converter = new TypeNameConverter();
                SomeType = (Type)converter.ConvertFrom(value);
            }
        }
        [XmlIgnore]
        public Type SomeType { get; set; }
    }
