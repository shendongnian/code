    public Dictionary<(string, string), int> GetPersonsPerGroup(IEnumerable<Home> homes ,List<string> gr, List<string> na)
    {
        return Filtered.GroupBy(x => (x.GroupName, x.PersonName))
            .ToDictionary(g => g.Key, g => g.Count);
    }
