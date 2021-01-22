    public interface IQueryable : IEnumerable {       
        Type ElementType { get; }
        Expression Expression { get; }
        IQueryProvider Provider { get; }
    }
    
    public interface IQueryProvider {
        IQueryable CreateQuery(Expression expression);
        IQueryable<TElement> CreateQuery<TElement>(Expression expression);
        object Execute(Expression expression);
        TResult Execute<TResult>(Expression expression);
    }
