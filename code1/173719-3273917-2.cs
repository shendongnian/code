    public IEnumerable<Item> GetAllBackReferences(Item search)
    {
        return PrivateGetAllBackReferences(search, search, new HashSet<Item>(), new HashSet<Item>());
    }
    
    private IEnumerable<Item> PrivateGetAllBackReferences(Item search, Item target, HashSet<Item> visited, HashSet<Item> matched)
    {
        if (!visited.Contains(search))
        {
            visited.Add(search);
            if (search == target)
            {
                matched.Add(search);
            }
            foreach (Item child in search.Dependencies)
            {
                PrivateGetAllBackReferences(child, target, visited, matched);
                if (child == target)
                {
                    if (!matched.Contains(search))
                    {
                        matched.Add(search);
                    }
                }
            }
        }
        return matched;
    }
