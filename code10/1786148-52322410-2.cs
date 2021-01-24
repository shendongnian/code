	[XmlRoot(ElementName = "Weight")]
    public class Weight
    {
        [XmlElement(ElementName = "Weight_A" /*, IsNullable = true*/)]
        public string Weight_A { get; set; }
        [XmlElement(ElementName = "Weight_B" /*, IsNullable = true*/)]
        public string Weight_B { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
	[XmlRoot(ElementName = "Density")]
    public class Density
    {
        [XmlElement(ElementName = "Density_A"/*, IsNullable = true*/)]
        public string Density_A { get; set; }
        [XmlElement(ElementName = "Density_B"/*, IsNullable = true*/)]
        public string Density_B { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public string Value { get; set; }
    }
