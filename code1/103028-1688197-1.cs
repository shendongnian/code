    public class TheresasSet {
        public string Name { get; set }
        public string Description { get; set; }
        public int ID { get; set; }
        public int Priority { get; set; }
        public bool Included { get; set; }
        public List<string> StringData { get; private set; }
    
        public TheresasSet() {
            StringData = new List<string>();
        }
    }
