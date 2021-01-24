    [Serializable()]
    public class Car
    {
        [System.Xml.Serialization.XmlElementAttribute("StockNumber")]
        public string StockNumber{ get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute("Make")]
        public string Make{ get; set; }
    
        [System.Xml.Serialization.XmlElementAttribute("Model")]
        public string Model{ get; set; }
    }
