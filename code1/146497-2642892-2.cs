    public IEnumerable<Data.Issue> Fetch(string type, FilterType filterType)
    { 
        var strategy = ioc.Resolve<IFilterStrategy>(type);
        IEnumerable<Data.Issue> results = null;
        switch(filterType)
        {
            case FilterType.New:
                results = strategy.FetchNew();
            default:
                 results = strategy.Ended();
        }
        return results; 
    }
