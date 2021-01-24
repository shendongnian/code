    [XmlRoot(ElementName = "Weight")]
    public class Weight
    {
        [XmlElement(ElementName = "Weight_A", IsNullable = true)]
        public string Weight_A { get; set; }
        public bool ShouldSerializeWeight_A() { return Weight_A != null; }
        [XmlElement(ElementName = "Weight_B", IsNullable = true)]
        public string Weight_B { get; set; }
        public bool ShouldSerializeWeight_B() { return Weight_B != null; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "Density")]
    public class Density
    {
        [XmlElement(ElementName = "Density_A", IsNullable = true)]
        public string Density_A { get; set; }
        public bool ShouldSerializeDensity_A() { return Density_A != null; }
        [XmlElement(ElementName = "Density_B", IsNullable = true)]
        public string Density_B { get; set; }
        public bool ShouldSerializeDensity_B() { return Density_B != null; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
