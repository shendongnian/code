    public IEnumerable<MuscleType> Get(params IncludeDefinition<MuscleType>[] includes)
    {
        IQueryable<MuscleType> muscleTypes = ...;
        foreach (var item in includes)
        {
            muscleTypes = item.Include(muscleTypes);
        }
        return muscleTypes.ToList();
    }
