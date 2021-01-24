    public IEnumerable<Muscle> Get(params IncludeDefinition<Muscle>[] includes)
    {
        IQueryable<Muscle> muscles = ...;
        foreach (var item in includes)
        {
            muscles = item.Include(muscles);
        }
        return muscles.ToList();
    }
