    public class MyClass
    {
        private Dictionary<int, List<string>> _someInternalDictionary;
        
        public List<string> MyValues
        {
            get
            {
                return _someInternalDictionary.Values;
            }
        }
    
    }
