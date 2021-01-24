    public static class XmlNamespaces
    {
        public const string Crsoftwareinc = "http://www.crsoftwareinc.com/xml/ns/titanium/common/v1_0";
    }
    [XmlRoot("field-value", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlType("field-value", Namespace = XmlNamespaces.Crsoftwareinc)]
    [XmlInclude(typeof(TextFieldValue)), 
    XmlInclude(typeof(DateFieldValue))]
    public abstract partial class FieldValue
    {
        // It's not necessary to have this in the base class but I usually find it convenient.
        public abstract object GetValue();
    }
