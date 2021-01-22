    class A
    {
        private SortedList<string, string> sortedList = new SortedList<string, string>();
        public IDictionary<string, string> SortedList 
        {
            get { return new ReadOnlyDictionaryWrapper(sortedList);
        }
    
        public A()
        {
            sortedList.Add("KeyA", "ValueA");
            sortedList["KeyA"] = "ValueAAA";
        }
    }
