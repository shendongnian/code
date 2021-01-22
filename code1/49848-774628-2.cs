    public static IEnumerable<string> GetPermutations(string s)
    {
        if (s.Count() > 1)
            return from ch in s
                   from permutation in GetPermutations(s.Remove(s.IndexOf(ch), 1))
                   select string.Format("{0}{1}", ch, permutation);
    
        else
            return new string[] { s };
    }
