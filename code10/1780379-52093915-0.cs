    public class Model
    {
        public List<string> objectId { get; set; }
        public List<string> name { get; set; }
    }
    
    public class Resource
    {
        public string id { get; set; }
        public Model model { get; set; }
        public int childs { get; set; }
        public int access { get; set; }
        public int allow { get; set; }
    }
