    [XmlRoot("field", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("field", Namespace = XmlNamespaces.Crsoftwareinc)]
    public class Field
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("field-value")]
        public FieldValue FieldValue { get; set; }
    }
    [XmlRoot("user-defined-data-row", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("user-defined-data-row", Namespace = XmlNamespaces.Crsoftwareinc)]
    public class UserDefinedDataRow
    {
        [XmlElement("field")]
        public List<Field> Fields { get; set; }
    }
    // The XML for the root object is not shown so this is just a stub
    [XmlRoot("root", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("root", Namespace = XmlNamespaces.Crsoftwareinc)]
    public class RootObject
    {
        [XmlElement("user-defined-data-row")]
        public List<UserDefinedDataRow> Rows { get; set; }
    }
