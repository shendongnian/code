    public void Execute(ref IQueryable<Event> input)
    {
        if (_eventTypes.Any())
        {
            //...
            if(condition != null)
            {
                var predicate = Expression.Lambda<Func<Event, bool>>(condition, parameter);
                input = input.Where(predicate);
            }
        }
    }
    //...
    public override IQueryable<Event> Process(IQueryable<Event> input)
    {
        foreach(var filter in _filters)
        {
            filter.Execute(ref input);
        }
        return input;
    }
