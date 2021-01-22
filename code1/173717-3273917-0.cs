    public IEnumerable<Item> GetAllDependencies(Item item)
    {
        return PrivateGetAllDependencies(item, new HashSet<Item>());
    }
    
    private IEnumerable<Item> PrivateGetAllDependencies(Item item, HashSet<Item> visited)
    {
        if (!visited.Contains(item))
        {
            visited.Add(item);
            foreach (Item child in item.Dependencies)
            {
                PrivateGetAllDependencies(child, visited);
            }
        }
        return visited;
    }
