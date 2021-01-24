    var t = Expression.Parameter(typeof(Model), "t");
    var body = Expression.And(
        Expression.Equal(Expression.PropertyOrField(t, "Name"), Expression.Constant("NAME")),
        Expression.Equal(Expression.PropertyOrField(t, "OpeningDate"), Expression.Constant(DateTime.Now))
    );
    var predicate = Expression.Lambda<Func<Model, bool>>(body, t);
