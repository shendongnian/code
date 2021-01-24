    public override IQueryable<Event> Process(IQueryable<Event> input)
    {
        foreach(var filter in _filters)
        {
            input = filter.Execute(input);
        }
        return input;
    }
