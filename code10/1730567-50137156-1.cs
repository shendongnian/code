    Type yourType = typeof(YourGeneric);
    ParameterExpression pe = Expression.Parameter(yourType , "x");
    Expression left = Expression.Property(pe, yourType.GetProperty(whereClause.ColumnName));
    Expression right = Expression.Constant(whereClause.Value, typeof(int));
    Expression result = Expression.Equal(left, right);
