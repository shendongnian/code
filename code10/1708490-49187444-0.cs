    public class SomeClass
    {
        private List<string> list = new List<string>();
        
        // Read-only property
        public List<string> List { get { return list } }
    }
