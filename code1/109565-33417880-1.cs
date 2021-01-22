    [XmlRoot(ElementName = "AFDPostcodeEverywhere")]
    public class AfdPostcodeEverywhere
    {
        [XmlElement(ElementName = "Result")]
        public int Result { get; set; }
        [XmlElement(ElementName = "ErrorText")]
        public string ErrorText { get; set; }
        [XmlElement(ElementName = "Items")]
        public List<Item> Items { get; set; }
    }
    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "AbbreviatedPostalCounty")]
        public string AbbreviatedPostalCounty { get; set; }
        [XmlElement(ElementName = "OptionalCounty")]
        public string OptionalCounty { get; set; }
        [XmlElement(ElementName = "AbbreviatedOptionalCounty")]
        public string AbbreviatedOptionalCounty { get; set; }
        [XmlElement(ElementName = "PostalCounty")]
        public string PostalCounty { get; set; }
        [XmlElement(ElementName = "TraditionalCounty")]
        public string TraditionalCounty { get; set; }
        [XmlElement(ElementName = "AdministrativeCounty")]
        public string AdministrativeCounty { get; set; }
        [XmlElement(ElementName = "Postcode")]
        public string Postcode { get; set; }
        [XmlElement(ElementName = "DPS")]
        public string Dps { get; set; }
        [XmlElement(ElementName = "PostcodeFrom")]
        public string PostcodeFrom { get; set; }
        [XmlElement(ElementName = "PostcodeType")]
        public string PostcodeType { get; set; }
        [XmlElement(ElementName = "Phone")]
        public string Phone { get; set; }
        [XmlElement(ElementName = "Key")]
        public string Key { get; set; }
        [XmlElement(ElementName = "List")]
        public string List { get; set; }
        [XmlElement(ElementName = "Locality")]
        public string Locality { get; set; }
        [XmlElement(ElementName = "Property")]
        public string Property { get; set; }
        [XmlElement(ElementName = "Street")]
        public string Street { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Organisation")]
        public string Organisation { get; set; }
        [XmlElement(ElementName = "Town")]
        public string Town { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public int Value { get; set; }
    }
