    public static IQueryable<T> GetByName<T>(this IQueryable<T> Entities, string Name, bool Active = true)
        where T : CMEntityBase //or the interface that specifies the needed members
    {
        return Entities.Where(ss => ss.Name == Name && ss.Active == Active || Active == false);
    }
