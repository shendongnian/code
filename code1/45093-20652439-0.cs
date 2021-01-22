    [Serializable]
    public class MyClass
    {
        [XmlElement(IsNullable = true)]
        public int? Age { get; set; }
        public int MyClassB { get; set; }
    }
