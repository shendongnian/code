        [XmlRoot("field-decimal-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
        [XmlType("field-decimal-valueType", Namespace = XmlNamespaces.Crsoftwareinc)]
        public class DecimalFieldValue : FieldValue
        {
            [XmlElement("value")]
            public decimal Value { get; set; }
            public override object GetValue() { return Value; }
        }
        [XmlInclude(typeof(DecimalFieldValue))]
        public abstract partial class FieldValue { }
    Don't forget to add `[XmlInclude(typeof(DecimalFieldValue))]` when doing so.
