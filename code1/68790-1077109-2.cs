        public TValue GetRandomElement<TKey, TValue>(SortedDictionary<TKey, TValue> dict)
        {
            Random randGen = new Random();
            int randIndex = randGen.Next(dict.Values.Count);
            int i = 0;
            foreach (TValue value in dict.Values)
            {
                if (i++ == randIndex)
                    return value;
            }
            
            // this shouldn't happen unless I have a bug above or you are accessing the dictionary from multiple threads
            return default(TValue);
        }
