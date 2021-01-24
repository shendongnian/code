    public static void Coder42(List<string> current, IEnumerable<string> news)
    {
        Dictionary<string, string> newDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        Dictionary<string, string> unfound = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var n in news)
        {
            if (n.Length < 6) throw new Exception("Too short");
            var ss = n.Substring(0, 6);
            if (newDict.ContainsKey(ss)) throw new Exception("Can't be too new.");
            newDict[ss] = n;
            unfound[ss] = n;
        }
        for (int i = 0; i < current.Count; i++)
        {
            var s = current[i];
            if (s.Length >= 6)
            {
                var ss = s.Substring(0, 6);
                if (newDict.TryGetValue(ss, out string replacement))
                {
                    current[i] = replacement;
                    unfound.Remove(ss);
                }
            }
        }
        foreach(var pair in unfound)
            current.Add(pair.Value);
    }
