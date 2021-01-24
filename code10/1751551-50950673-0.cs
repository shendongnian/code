    public class MyDictionary
    {
        public Dictionary<string,object> Dictionary{get;}
        public MyDictionary()
        {
            Dictionary = new Dictionary<string,object>();
        }
        public void Add(string key, object value){
            Dictionary.Add(key,value);
        }
    }
