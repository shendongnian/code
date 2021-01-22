    public class Group {
        public Group() {}
        [XmlAttribute("id")]
        public int Id {get;set;}
        [XmlAttribute("name")]
        public string Name {get;set;}
        [XmlAttribute("parentid")]
        public int ParentId {get;set;}
    }
