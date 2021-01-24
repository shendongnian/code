    // This does not need to be generic in any way
    public interface IObjectWithId
    {
        int Id {get;set;}
    }
    public static IEnumerable<T> Get<T>(this IEnumerable<T> list, List<int> ids)
        where T : IObjectWithId
    {
        return list.Where(i => ids.Contains(i.Id));
    }
