    public Expression CreateExpression<TEntity, TConst>(WhereClause singleWhere)
    { 
        Type entityType = typeof(TEntity);
        ParameterExpression pe = Expression.Parameter(entityType, "x");
        Expression left = Expression.Property(pe, 
            entityType.GetProperty(singleWhere.ColumnName));
        Expression right = Expression.Constant(singleWhere.Value, typeof(TConst));
        return getOperatorExp(singleWhere.Operator, left, right);
    }
