    public IEnumerable<Item> GetAllDependencies(Item search)
    {
        return PrivateGetAllDependencies(search, new HashSet<Item>());
    }
    
    private IEnumerable<Item> PrivateGetAllDependencies(Item search, HashSet<Item> visited)
    {
        if (!visited.Contains(search))
        {
            visited.Add(search);
            foreach (Item child in search.Dependencies)
            {
                PrivateGetAllDependencies(child, visited);
            }
        }
        return visited;
    }
