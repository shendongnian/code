        public static IDictionary<T1, T2> MergeAllOverwrite<T1, T2>(IList<IDictionary<T1, T2>> allDictionaries)
        {
            var initSize = allDictionaries.Sum(d => d.Count);
            var resultDictionary = new Dictionary<T1, T2>(initSize);
            allDictionaries.ForEach(resultDictionary.MergeOverwrite);
            return resultDictionary;
        }
