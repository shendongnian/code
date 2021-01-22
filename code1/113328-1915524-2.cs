    class Main
    {
        void DoIt()
        {
            Thing[] collection = new [] { new Thing(), new Thing() };
            var lookupTable = new Dictionary<KeyValuePair<int, string>, List<int>>();
            int index = 0;
            foreach (Thing item in collection)
            {
                KeyValuePair<int, string> key = new KeyValuePair<int, string>(item.Bar, item.Foo.Key);
                if (!lookupTable.ContainsKey(key))
                    lookupTable.Add(key, new List<int>());
                lookupTable[key].Add(index++);
            }
        }
    }
    class Thing
    {
        public KeyValuePair<string, List<string>> Foo { get; set; }
        public int Bar { get; set; }
    }
