    public interface IFilterable
    {
         bool Match(string match);
    }
    public static IEnumerable<T> Search<T>(this IEnumerable<T> source, string match) where T: IFilterable
    {
        return source.Where(x=>x.Match(match));
    }
