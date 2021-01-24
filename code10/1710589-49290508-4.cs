    public static class LinqExtensions
    {
        public static IEnumerable<T> CustomParameterQuery<T>(this IEnumerable<T> entities, Dictionary<string, object> queryVars)
        {
            if (entities.Count() == 0 || queryVars.Count == 0)
            {
                return entities;
            }
    
            //create a new expression for the type of person this.
            var paramExpr = Expression.Parameter(typeof(T));
    
            BinaryExpression equalExpression = null;
            foreach (var kvp in queryVars)
            {
                var e = BuildExpression(paramExpr, kvp.Key, kvp.Value);
                if (equalExpression == null)
                    equalExpression = e;
                else
                    equalExpression = Expression.And(equalExpression, e);
            }
    
            if (equalExpression == null)
            {
                return new T[0];
            }
            //next we convert the expression into a lamba expression
            var lExpr = Expression.Lambda<Func<T, bool>>(equalExpression, paramExpr);
            //finally we query our dataset
            return entities.AsQueryable().Where(lExpr);
        }
    
        static BinaryExpression BuildExpression(Expression expression, string propertyName, object value)
        {
            //next we create a property expression based on the property name
            var property = Expression.Property(expression, propertyName);
    
            //next we create a constant express based on the country id passed in.
            var constant = Expression.Constant(value);
    
            //next we create an "Equals" express where property equals containt. ie. ".CountryId" = 1
            return Expression.Equal(property, constant);
        }
    }
