    public class FinalConcentrations {
        private readonly List<string> items = new List<string>();
        [XmlElement("FinalConcentration")]
        public List<string> Items {get {return items;}}
    }
