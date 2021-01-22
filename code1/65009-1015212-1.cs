        protected TLinqEntity GetByID(object id, DataContext dataContextInstance)
        {
            return dataContextInstance.GetTable<TLinqEntity>()
                .SingleOrDefault(GetIDWhereExpression(id));
        }
----------
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
        static PropertyInfo GetPrimaryKey(Type entityType)
        {
            foreach (PropertyInfo property in entityType.GetProperties())
            {
                var attributes = (ColumnAttribute[])property.GetCustomAttributes(typeof(ColumnAttribute), true);
                if (attributes.Length == 1)
                {
                    ColumnAttribute columnAttribute = attributes[0];
                    if (columnAttribute.IsPrimaryKey)
                    {
                        if (property.PropertyType != typeof(int))
                        {
                            throw new ApplicationException(string.Format("Primary key, '{0}', of type '{1}' is not int",
                                property.Name, entityType));
                        }
                        return property;
                    }
                }
            }
            throw new ApplicationException(string.Format("No primary key defined for type {0}", entityType.Name));
        }
