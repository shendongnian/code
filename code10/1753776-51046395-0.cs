    namespace System.Linq
    {
    	public static class QueryableExtensions
    	{
    		public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool ascending)
    		{
    			return ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
    		}
    	}
    }
