    using System; 
     using System.Collections.Generic; 
     using System.Linq; 
     using System.Linq.Expressions; 
    public class GenericSorter<T> {
    public IEnumerable<T> Sort(IEnumerable<T> source, string sortBy, string sortDirection)
    {
        var param = Expression.Parameter(typeof(T), "item");
        var sortExpression = Expression.Lambda<Func<T, object>>
            (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);
        switch (sortDirection.ToLower())
        {
            case "asc":
                return source.AsQueryable<T>().OrderBy<T, object>(sortExpression);
            default:
                return source.AsQueryable<T>().OrderByDescending<T, object>(sortExpression);
        } 
    }
