    [Serializable]
    [XmlRoot(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", ElementName = "Description")]
    public class BasicEntity
    {
        [XmlElement(Namespace = "http://s.opencalais.com/1/pred/", ElementName = "name")]
        public string Name { get; set; }
        [XmlAttribute("about", Form=XmlSchema.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
        public string Uri { get; set; }
    }
