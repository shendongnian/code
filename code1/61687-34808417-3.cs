        public int Count { 
            get {  return dictContext.Count();  }
        }
        public Dictionary<int, T>.KeyCollection Keys
        {
            get { return dictContext.Keys; }
        }
        public Dictionary<int, T>.ValueCollection Values
        {
            get { return dictContext.Values; }
        }
        public void Add (int key, T value)
        {
            dictContext.Add(key, value);
        }
        public bool Remove (int key)
        {
           return  dictContext.Remove(key);
        }
