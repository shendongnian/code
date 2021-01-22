    public virtual T GetById<T>(short id)
            {
                var itemParameter = Expression.Parameter(typeof(T), "item");
                var whereExpression = Expression.Lambda<Func<T, bool>>
                    (
                    Expression.Equal(
                        Expression.Property(
                            itemParameter,
                            "id"
                            ),
                        Expression.Constant(id)
                        ),
                    new[] { itemParameter }
                    );
                var table = DB.GetTable<T>();
                return table.Where(whereExpression).Single();
            }
