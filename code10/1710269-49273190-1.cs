    public List<RetailGroup> SearchGroupsAndStores(string value)
    {
    	List<RetailGroup> searchResults = new List<RetailGroup>();
    	searchResults.AddRange(_context.RetailGroups.Where(rg => rg.GroupName.Contains(value)).ToList());
    	searchResults.AddRange(_context.RetailStores.Where(rs => rs.StoreName.Contains(value)).Select(rs => rs.RetailGroup).ToList());
    }
