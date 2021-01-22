    public virtual T GetById(int id)
    {
        var itemParameter = Expression.Parameter(typeof(T), "item");
        var whereExpression = Expression.Lambda<Func<T, bool>>
            (
            Expression.Equal(
                Expression.Property(
                    itemParameter,
                    typeof(T).GetPrimaryKey().Name
                    ),
                Expression.Constant(id)
                ),
            new[] { itemParameter }
            );
         return GetAll().Where(whereExpression).Single();
    }
