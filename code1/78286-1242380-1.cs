    public static IQuearyable<Person> Famales(IQueryable<Person> this entry)
    {
        return entry.Where(p => p.Gender == Gender.Female);
    }
    
    public static IQuearyable<Person> LivingInState(IQueryable<Person> this entry, State state)
    {
        return entry.Where(p => p.State == state);
    }
    public static IQuearyable<Person> PeopleWithAddress(IQueryable<Person> this entry)
    {
        return entry.Where(p => p.Address != null);
    }
    // Use like this
    var marriedFemales = GetPersonsQuery().Females().Where(f => f.IsMarried)
    var femaleVictorians = GetPersonsQuery().Females().LivingInState(State.Victoria)
    var femaleVictorians = GetPersonsQuery().PeopleWithAddress()
        .Females().Where(x => x.IsMarried)
        .Select( x => new { x.LastName, x.Address} )
