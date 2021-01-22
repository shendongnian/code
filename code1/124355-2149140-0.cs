    public static class DictionaryResource
    {
        // make dictonary internal so the only way to access it is through a public property
        internal static Dictionary<string, int> theDictionary = new Dictionary<string, int>();
    
        // utility methods :
        // 1. add a new Key-Value Pair (KVP)
        public static void AddKVP(string theString, int theInt)
        {
            if (! theDictionary.ContainsKey(theString))
            {
                theDictionary.Add(theString, theInt);
            }    
        }
        // 2. delete an existing KVP
        public static void RemoveKVP(string theString)
        {
            if (theDictionary.ContainsKey(theString))
            {
                theDictionary.Remove(theString);
            }
        }
        // 3. revise the value of an existing KVP
        public static void ChangeDictValue(string theString, int theValue)
        {
            if(theDictionary.ContainsKey(theString))
            {
                theDictionary[theString] = theValue;
            }
        }
        // expose the internal Dictionary via a public Property 'getter
        public static Dictionary<string,int> TheDictionary
        {
           get { return theDictionary; }
        }
    }
