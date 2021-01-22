    var resultList =   presentList
            .MyOrderBy(x => x.Something)
            .MyOrderBY(y => y.SomethingElse)
            .MyOrderByDesc(z => z.AnotherThing)
    
    public IQueryable<T> MyOrderBy(IQueryable<T> prevList, Expression<Func<T, U>> predicate) {
    
           return (prevList is IOrderedQueryable<T>)
                ? query.ThenBy(predicate)
                : query.OrderBy(predicate);
    }
    
    public IQueryable<T> MyOrderByDesc(IQueryable<T> prevList, Expression<Func<T, U>> predicate) {
    
           return (prevList is IOrderedQueryable<T>)
                ? query.ThenByDescending(predicate)
                : query.OrderByDescending(predicate);
    }
