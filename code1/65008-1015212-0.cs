        protected TLinqEntity GetByID(object id, DataContext dataContextInstance)
        {
            return dataContextInstance.GetTable<TLinqEntity>()
                .SingleOrDefault(GetIDWhereExpression(id));
        }
        static Expression<Func<TLinqEntity, bool>> GetIDWhereExpression(object id)
        {
            var itemParameter = Expression.Parameter(typeof(TLinqEntity), "item");
            return Expression.Lambda<Func<TLinqEntity, bool>>
                (
                Expression.Equal(
                    Expression.Property(
                        itemParameter,
                        TypeExtensions.GetPrimaryKey(typeof(TLinqEntity)).Name
                        ),
                    Expression.Constant(id)
                    ),
                new[] { itemParameter }
                );
        }
