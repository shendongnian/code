    public class Container : XmlElementGenerator
    {
        public string projectcode { get; set; }
        public string projectname { get; set; }
        public string projectleader { get; set; }
        public string barcode { get; set; }
        public string sampleartid { get; set; }
        public string sampledescription { get; set; }
        public string remark { get; set; }
        public DateTime samplingdate { get; set; }
        public int samplenumber { get; set; }
    
        public XmlElement GenerateXMLElement(XmlDocument xmlDocument)
        {
           XmlElement container = ElementChildrenGenerator(xmlDocument,"container");
    
            foreach (PropertyInfo prop in this.GetType().GetProperties())
            {
                container.AppendChild(ElementChildrenGenerator(xmlDocument, prop.Name, prop.GetValue(this).ToString()));
            }
    
            return container;
        }
    
    }
