    public class MyClass
    {
        private Dictionary<int, List<string>> _someInternalDictionary;
        
        public int MyValuesCount
        {
            get
            {
                return _someInternalDictionary.Values.Count;
            }
        }
    
    }
