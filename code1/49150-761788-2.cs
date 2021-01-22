    public static IQueryable<Parent> FilterByChildId(
       this IQueryable<Parent> parents, Int32 id)
    {
       return parents.Where(p => p.Childs.Any(c => c.Id == id));
    }
