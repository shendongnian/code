    public interface IOrderByExpression<T>
    {
      ApplyOrdering(ref IQueryable<T> query);
    }
    public class OrderByExpression<T, U> : IOrderByExpression<T>
    {
      public IQueryable<T> ApplyOrderBy(ref IQueryable<T> query)
      {
        query = query.OrderBy(exp);
      }
      //TODO OrderByDescending, ThenBy, ThenByDescending methods.
      private Expression<Func<T, U>> exp = null;
 
      //TODO bool descending?
      public OrderByExpression (Expression<Func<T, U>> myExpression)
      {
        exp = myExpression;
      }
    }
