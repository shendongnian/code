    public static IQueryable<Parent> FilterByChildId(
       this IQueryable<Parent> parents, Int32 id)
    {
       return parents.Where(p => p.Child.Id == id);
    }
