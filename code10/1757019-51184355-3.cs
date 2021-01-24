    public static class DictionaryExtensions
    {
        private static IEqualityComparer<string> _comparer = new LevenshteinStringComparer(distance);
        public static IEnumerable<T> FuzzyMatch<T>(this IDictionary<string, T> dictionary, string key, int distance = 2)
        {
            return dictionary
                .Keys
                .Where(k => _comparer.Equals(k, key))
                .Select(k => dictionary[k]);
        }
    }
