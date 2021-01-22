    private static IList<T> GetList(RequestForm form) where T : OrderedValueContainer
    {
        // we'll want to somehow genericize the idea of a TypeRepository that can
        // produce these types; if that can't be done, we're probably better off
        // passing a repository into this function rather than creating it here
        var repository = new TypeRepository<T>(new HybridSessionBuilder());
        IList<T> myTypes = repository.GetAll();
        // the hypothetical OrderedValueContainer class
        // contains definitions for Active, Value, and DisplayOrder
       
        return myTypes.Where(x => x.Active || form.SolutionType.Contains(x.Value))
                      .OrderBy(x => x.DisplayOrder).ToList();
    }
