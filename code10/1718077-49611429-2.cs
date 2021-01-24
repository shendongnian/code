    class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.IndexOf(y, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        public int GetHashCode(string obj)
        {
            return 0;
        }
    }
    public static int CalculateSearchRelevance(string searchItem, IEnumerable<string> searchWords)
    {
        var searchItemWords = searchItem.Split(null).ToList();
        return searchWords.Intersect(searchItemWords, new MyComparer()).Count();
    }
