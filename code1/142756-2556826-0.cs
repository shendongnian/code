    interface IEnumerable<T> {
        ...
        // Actually, these are extension methods in Enumerable and Queryable.
        IEnumerable<T> Select<TResult>(Func<T, TResult> selector);
        ...
    }
    
    interface IQueryable<T> : IEnumerable<T> {
        ...
        IQueryable<T> Select<TResult>(Expression<Func<T, TResult>> selector);
        ...
        IEnumerable<T> AsEnumerable();
    }
    IEnumerable<IEvent> events = db.getEvents().AsEnumerable().Select(x => SelectEvent(x, null));
