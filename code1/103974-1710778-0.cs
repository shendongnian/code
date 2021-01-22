    var now = DateTime.Now;
    var myObjects = session
        .CreateCriteria<MyObject>()
        .CreateAlias("SubObject", "so")
        .Add(
            Expression.And(
                Expression.Or(
                    Expression.And(
                        Expression.IsNotNull("SubObject"),
                        Expression.IdEq(10)
                    ),
                    Expression.IsNull("SubObject")
                ),
                Expression.And(
                    Expression.Or(
                        Expression.And(
                            Expression.IsNotNull("EndDate"),
                            Expression.Ge("EndDate", now)
                        ),
                        Expression.IsNull("EndDate")
                    ),
                    Expression.Le("StartDate", now)
                )
            )
        )
        .List<MyObject>();
