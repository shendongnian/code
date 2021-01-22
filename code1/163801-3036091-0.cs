    public class b {
        public string c { get; set; }
        public string d { get; set; }
    }
    
    [XmlRoot(Namespace="", ElementName="a")]
    public class a : List<b> { }
