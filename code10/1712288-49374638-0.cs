    public static class EntityTypeConfigurationExtensions
    {
        public static void ComplexProperty<T>(
            this EntityTypeConfiguration<T> configuration,
            Expression<Func<T, string>> expression) 
            where T : class
        {
            var columnName = expression.Body.ToString().Split('.')[1];
            configuration.Property(expression).HasColumnName(columnName);
        }
    }
