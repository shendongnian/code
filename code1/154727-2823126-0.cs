    [XmlRoot("Movimientos")]
    public class Movimientos
    {
        [XmlElement("Movimientos")]
        public SomeOtherClass SomeOtherProperty { get; set; }
    }
    public class SomeOtherClass
    {
        public string NOM_ASOC { get; set; }
        public string FEC1 { get; set; }
        public string IDENT_CLIE { get; set; }
    }
