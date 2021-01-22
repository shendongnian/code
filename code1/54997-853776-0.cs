    public class DictContainer
    {
        private readonly Dictionary<int, int> myDictionary;
    
        public DictContainer()
        {
            myDictionary = GetDictionary();
        }
    
        private Dictionary<int, int> GetDictionary()
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
    
            myDictionary.Add(1, 2);
            myDictionary.Add(2, 4);
            myDictionary.Add(3, 6);
    
            return myDictionary;
        }
    
        public this[int key]
        {
            return myDictionary[key];
        }
    }
