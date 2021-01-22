    public ObjectQuery<E> DoQuery(ISpecification<E> where)
    {
        var esql = String.Concat(
             "SELECT VALUE e1 FROM OFTYPE(", 
             GetEntitySetName(typeof(E)),
             ", ", 
             typeof(T).FullName, 
             ") AS e1");
        return Context.CreateQuery<T>(esql).Include("User").Where(where.EvalPredicate);
    }
