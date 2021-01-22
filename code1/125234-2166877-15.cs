    private void PopulateTree(IEnumerable<MyObject> items)
    {
        // Snip lookup-generation code - same as before ...
        List<string> path = new List<string>();
        foreach (string parent in lookup.Keys)
        {
            if (lookup.ContainsKey(parent))
                AddToTree(lookup, path, parent);
        }
    }
    private void AddToTree(Dictionary<string, IEnumerable<string>> lookup,
        IEnumerable<string> path, string name)
    {
        IEnumerable<string> children;
        if (lookup.TryGetValue(name, out children))
        {
            path.Add(name);
            foreach (string child in children)
                AddToTree(lookup, newPath, child);
            path.Remove(name);
        }
        // Snip "else" block - again, this part is the same as before ...
    }
