    [XmlRoot("field-text-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("field-text-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
    public class TextFieldValue : FieldValue
    {
        [XmlElement("value")]
        public string Value { get; set; }
        public override object GetValue() { return Value; }
    }
    [XmlRoot("field-date-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("field-date-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
    public class DateFieldValue : FieldValue
    {
        [XmlElement("value", DataType = "date")]
        public DateTime Value { get; set; }
        public override object GetValue() { return Value; }
    }
