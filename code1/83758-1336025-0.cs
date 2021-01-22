        Expression<Func<FooEntity, bool>> seed = l => false;
        var predicate = controlsToGet.Aggregate(seed,
            (e, c) => Expression.Lambda<Func<DataEventAttribute, bool>>(
                Expression.OrElse(
                    Expression.Equal(
                        Expression.Property(
                            Expression.Property(
                                e.Parameters[0],
                                "Control"),
                            "Name"),
                        Expression.Constant(c)),
                    e.Body),
                e.Parameters));
        var all = fooelements.Where(predicate);
