    private IOrderedEnumerable<PropertyInfo> GetSortedPropInfos()
    {
        return dataExtractor.GetType()
                            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                            .OrderBy( p => p.Name );
    }
