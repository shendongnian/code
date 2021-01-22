    class MovieTitle
    {
        [XmlText]
        public string Title { get; set; }
        [XmlAttribute(Namespace="http://www.myxmlnamespace.com")]
        public string uid { get; set; }
        public override ToString() { return Title; }
    }
    [XmlElement(ElementName = "Title")]
    public MovieTitle Title;
