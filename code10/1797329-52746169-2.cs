    public interface IFilterable
    {
         bool Match(string match);
    }
    public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string match) where T: IFilterable
    {
        foreach(var e in source)
        {
            if(e.Match(match)) yield return e;
        }
    }
