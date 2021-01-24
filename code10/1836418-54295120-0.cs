    public static class CustomQueryBuilder
    {
        //todo: add more operations
        public enum Operator
        {
            Equal = 0,
            GreaterThan = 1,
            LesserThan = 2
        }
        public static IQueryable<T> Where<T>(this IQueryable<T> query, string property, Operator operation, object value)
        {
            //it's an item which property we are referring to
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            //this stands for "item.property"
            Expression prop = Expression.Property(parameter, property);
            //wrapping our value to use it in lambda
            ConstantExpression constant = Expression.Constant(value);
            Expression expression;
            //creating the operation
            //todo: add more cases
            switch (operation)
            {
                case Operator.Equal:
                    expression = Expression.Equal(prop, constant);
                    break;
                case Operator.GreaterThan:
                    expression = Expression.GreaterThan(prop, constant);
                    break;
                case Operator.LesserThan:
                    expression = Expression.LessThan(prop, constant);
                    break;
                default:
                    throw new ArgumentException("Invalid operation specified");
            }
            //create lambda ready to use in queries
            var lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);
            return query.Where(lambda);
        }
    }
