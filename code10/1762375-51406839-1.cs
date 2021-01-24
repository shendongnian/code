    [XmlType("Principle", Namespace = "http://www.archimatetool.com/archimate")]
    public class Principle : Element
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
    }
    
    [XmlRoot(ElementName = "element", Namespace = "http://www.archimatetool.com/archimate")]
    [XmlInclude(typeof(Principle))]
    public class Element
    {
        [XmlAttribute(AttributeName = "type", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Type { get; set; }
    }
