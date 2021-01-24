    [XmlRoot("ObjectID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class ObjectID
    {
        [XmlAttribute("d", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string D { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot("ContactID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public class ContactID
    {
        [XmlAttribute("d", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string D { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
    [XmlRoot("properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public class Properties
    {
        [XmlElement("ObjectID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public ObjectID ObjectID { get; set; }
        [XmlElement("ContactID", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
        public ContactID ContactID { get; set; }
        [XmlAttribute("m", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string M { get; set; }
    }
    [XmlRoot("Content")]
    public class MyDto
    {
        [XmlElement("properties", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
        public Properties Properties { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
