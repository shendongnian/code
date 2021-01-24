    [XmlRoot("TracelinkOrder")]
    public class TraceLinkOrder
    {
        [XmlAttribute()]
        public Int16 DocType { get; set; }
    
        [XmlAttribute()]
        public Boolean Annulation { get; set; }
    
        [XmlAttribute()]
        public Int16 TROrderType { get; set; }
    
        [XmlAttribute()]
        public Int16 Department { get; set; }
    
        [XmlElement("TracelinkOrderLine")]
        public List<TraceLinkOrderLine> OrderLines { get; set; }
    }
