    public class RepoData
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public bool enabled { get; set; }
        public bool available { get; set; }
        public string location { get; set; }
        public string path { get; set; }
    }
    
    public class RootObject4
    {
        public List<RepoData> repoData { get; set; }
    }
