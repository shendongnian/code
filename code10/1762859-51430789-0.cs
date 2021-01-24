    public interface ICollection<T>
    {
        Dictionary<string,T> TypeDictionary { get; set; }
        void AddToDictionary(Dictionary<string,T> Addition
        int FileCount { get; }
    }
    
    public class TypeACollection : ICollection<TypeA>
    {
        private Dictionary<string,TypeA> myTypeDictionary = new Dictionary<string, TypeA>();
        public void AddToDictionary(Dictionary<string, TypeA> Addition)
        {
            foreach (var keyValuePair in Addition)
            {
                TypeDictionary[keyValuePair.Key] = keyValuePair.Value;
            }
        }
        public Dictionary<string, TypeA> GetTypeDictionary()
        {
            return TypeDictionary;
        }
    
        private void ClearDictionary()
        {
            TypeDictionary.Clear();
        }
    
        public Dictionary<string, TypeA> TypeDictionary { 
             get {   return myTypeDictionary; } 
             set {   myTypeDictionary = value; } 
        }
    
        public int FileCount {get { return TypeDictionary.Keys.Count; }}
    }
    public class TypeA { }
    public class TypeB { }
