    Expression<Func<TEntity, bool>> Combined
    {
        get
        {
            var entity = Expression.Parameter(typeof(TEntity));
            var pa = Expression.Invoke(PropertyAccessor, entity);
            var te = Expression.Invoke(TestExpression, pa);
            return (Expression<Func<TEntity, bool>>) Expression.Lambda(te, entity);
        }
    }
