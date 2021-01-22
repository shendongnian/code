    public static IQuearyable<Person> Famales(IQueryable<Person> this entry)
    {
        return entry.Where(p => p.Gender == Gender.Female);
    }
    
    public static IQuearyable<Person> LivingInState(IQueryable<Person> this entry, State state)
    {
        return entry.Where(p => p.State == state);
    }
    // Use like this
    var marriedFemales = GetPersonsQuery().Females().Where(f => f.IsMarried)
    var femaleVictorians = GetPersonsQuery().Females().LivingInState(State.Victoria)
