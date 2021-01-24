    public static class ConfigurationExtensions
    {
        public static EntityTypeConfiguration<T> HasKey<T>(this EntityTypeConfiguration<T> config, PropertyInfo property) where T : class
        {
            //entity type
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            //entity.key
            Expression prop = Expression.Property(parameter, property.Name);
             //entity => entity.key
            var lambda = Expression.Lambda(prop, parameter);
            MethodInfo hasKeyMethod = typeof(EntityTypeConfiguration<T>)
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == nameof(EntityTypeConfiguration<T>.HasKey)
                    && m.GetParameters().Count() == 1)
                .First()
                .MakeGenericMethod(property.PropertyType);
            return (EntityTypeConfiguration<T>)hasKeyMethod.Invoke(config, new object[] { lambda });
        }
    }
