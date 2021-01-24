    public class Item
        {           
            [XmlAttribute()]
            public string Price;
            [XmlAttribute()]
            public string UnitOfMeasure;      
            [XmlElement("TaxAmount")]
            public TaxDetails taxdetails;
        }
        
        public class TaxDetails
        {
            [XmlAttribute()]
            public string Included;
            [XmlAttribute()]
            public string Amount;
        }
