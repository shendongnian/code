        public TValue GetRandomElement<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            var randGen = new Random();
            var randIndex = randGen.Next(dict.Values.Count);
            return dict.Values.ElementAt(randIndex);
        }
