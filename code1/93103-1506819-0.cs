    public class Result
    {
        [XmlIgnore]
        public String htmlValue
        {
            get;
            set;
        }
    
        private static XmlDocument _dummyDoc;
    
        [XmlElement("htmlValue")]
        public XmlCDataSection htmlValueCData
        {
            get { return _dummyDoc.CreateCDataSection(htmlValue); }
            set { htmlValue = (value != null) ? value.Data : null; }
        }
    }
