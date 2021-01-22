    IQueryable<Vehicle> Vehicles { get; }
    
    // raw data
    public static IQueryable<Vehicle> OwnedBy(this IQueryable<Vehicle> query, int ownerId)
    {
        return query.Where(v => v.OwnerId == ownerId);
    }
    // business purpose
    public static IQueryable<Vehicle> UsedThisYear(this IQueryable<Vehicle> query)
    {
        return query.Where(v => v.LastUsed.Year == DateTime.Now.Year);
    }
Both methods are simple query extensions, but however subtle they have different roles. The first is a simple filter, while the second implies business need (ex. maintenance or billing). In a simple application one might implement them both in a repository. In a more idealistic system UsedThisYear is best suited for the service layer (and may even be implemented as a normal instance method) where it may also better facilitate *CQRS* strategy of separating *commands* and *queries*.
