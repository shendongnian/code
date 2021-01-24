    public static class DictionaryExtensions
    {
        public static IEnumerable<int> FuzzyMatch(this IDictionary<string, int> dictionary, string key, int distance = 2)
        {
            var comparer = new LevenshteinStringComparer(distance);
            return dictionary
                .Keys
                .Where(k => comparer.Equals(k, key))
                .Select(k => dictionary[k]);
        }
    }
