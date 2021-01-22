    public static class Extensions
    {
        public static bool ContainsAny(this string stringToCheck, IEnumerable<string> stringArray)
        {
            Trie trie = new Trie(stringArray);
            for (int i = 0; i < stringToCheck.Length; ++i)
            {
                if (trie.MatchesPrefix(stringToCheck.Substring(i)))
                {
                    return true;
                }
            }
    
            return false;
        }
    }
