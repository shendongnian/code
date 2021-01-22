    public enum ComparisonType { StartsWith, EndsWith, Contains }
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereLike<T>(
            this IQueryable<T> source,
            Expression<Func<T, string>> field, 
            string value,
            SelectedComparisonType comparisonType)
        {
            ParameterExpression p = field.Parameters[0];
            return source.Where(
                Expression.Lambda<Func<T, bool>>(
                    Expression.Call(
                        field.Body, 
                        comparisonType.ToString(), 
                        null, 
                        Expression.Constant(value)),
                p));
        }
    }
