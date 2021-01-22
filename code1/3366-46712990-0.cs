    private List<SearchResult> GetFinalSearchResults(IEnumerable<IEnumerable<SearchResult>> lists)
    {
        Dictionary<int, SearchResult> oldList = new Dictionary<int, SearchResult>();
        Dictionary<int, SearchResult> newList = new Dictionary<int, SearchResult>();
    
        oldList = lists.First().ToDictionary(x => x.EmployeeId, x => x);
    
        foreach (List<SearchResult> list in lists.Skip(1))
        {
            foreach (SearchResult emp in list)
            {
                if (oldList.Keys.Contains(emp.EmployeeId))
                {
                    newList.Add(emp.EmployeeId, emp);
                }
            }
    
            oldList = new Dictionary<int, SearchResult>(newList);
            newList.Clear();
        }
    
        return oldList.Values.ToList();
    }
