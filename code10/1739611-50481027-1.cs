    [XmlRoot("Model")]
    public class Model
    {       
        //[XmlElement(ElementName = "Content")]
        [XmlAttribute(AttributeName = "Content")]
        public string Content { get; set; }
