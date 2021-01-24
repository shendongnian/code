    public class Provider
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public IList<string> Ids { get; set; }
        public IList<string> specialIds { get; set; }
        public Options options { get; set; }
    }
    
    public class Options
    {
        public bool isAccepting { get; set; }
    }
