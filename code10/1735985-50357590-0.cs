    public class Item
    {           
        [XmlAttribute()]
        public string Price;
        [XmlAttribute()]
        public string UnitOfMeasure;      
        [XmlElement("")]
        public TaxDetails TaxAmount;
    }
    
    public class TaxDetails
    {
        [XmlAttribute()]
        public string Included;
        [XmlAttribute()]
        public string Amount;
    }
