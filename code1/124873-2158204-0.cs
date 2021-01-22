    public class SomeClass()
    {
        private List<string> _someList = new List<string>();
    
        public IList<string> SomeList 
        { 
             get { return _someList.AsReadOnly(); } 
        }
    }
