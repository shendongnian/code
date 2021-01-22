        public static void MergeOverwrite<T1, T2>(this IDictionary<T1, T2> dictionary, IDictionary<T1, T2> newElements)
        {
            if (newElements == null) return;
            foreach (var e in newElements)
            {
                dictionary.Remove(e.Key); //or if you don't want to overwrite do (if !.Contains()
                dictionary.Add(e);
            }
        }
