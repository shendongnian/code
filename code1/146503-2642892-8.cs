    public IEnumerable<Data.Issue> Fetch(string dataType, FilterType filterType)
    { 
        var strategy = ioc.Resolve<IDataStrategy>(dataType);
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
