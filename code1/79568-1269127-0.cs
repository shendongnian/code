    public class ExampleImage
    {
        public int ID { get; set; }
        public string Filename { get; set; }
    
        [XmlIgnore]
        public byte[] Content { get; set; }
    
        [XmlElement("Content")]
        public string ContentBase64
        {
            get { return Convert.ToBase64String(Content); }
            set { Content = Convert.FromBase64String(value); }
        }
    }
