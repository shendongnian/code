    var parameter = Expression.Parameter(typeof(Record));
    var body = listOfBranch
    	.Select(b => Expression.AndAlso(
    		Expression.Equal(Expression.Property(parameter, "ID"), Expression.Constant(b.ID)),
    		Expression.Equal(Expression.Property(parameter, "Code"), Expression.Constant(b.Code))))
    	.Aggregate(Expression.OrElse);
    var predicate = Expression.Lambda<Func<Record, bool>>(body, parameter);
