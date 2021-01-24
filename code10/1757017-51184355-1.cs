    public static class DictionaryExtensions
    {
        public static IEnumerable<T> FuzzyMatch<T>(this IDictionary<string, T> dictionary, string key, int distance = 2)
        {
            var comparer = new LevenshteinStringComparer(distance);
            return dictionary
                .Keys
                .Where(k => comparer.Equals(k, key))
                .Select(k => dictionary[k]);
        }
    }
