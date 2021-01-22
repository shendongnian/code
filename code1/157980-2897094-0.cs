    public IList<System.String> Clean(IList<System.String> words)
    {
        return words.Where(p => !string.IsNullOrEmpty(p) && p.Length > 2)
                    .Distinct()
                    .ToList();
    }
