    public static Expression<Func<T, bool>> MakeExpression<T>(DateTime myDateField, string fieldName)
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            var property = Expression.Property(parameter, fieldName);
            var fieldType = property.Type;
            Expression<Func<T, bool>> lambda = null;
            if (fieldType == typeof(DateTime?))
            {
                var truncateTimeMethod = typeof(DbFunctions).GetMethod("TruncateTime", new[] { fieldType });
                if (truncateTimeMethod != null)
                {
                    var propertyHasvalue = Expression.Property(property, nameof(Nullable<DateTime>.HasValue));
                    var truncateTimeMethodCall = Expression.Call(truncateTimeMethod, property);
                    var ternary = Expression.Condition(Expression.Not(propertyHasvalue), property, truncateTimeMethodCall);
                    var argument = Expression.Constant(myDateField.Date, typeof(DateTime?));
                    var equalExp = Expression.Equal(ternary, argument);
                    lambda = Expression.Lambda<Func<T, bool>>(equalExp, parameter);
                }
            }
            return lambda;
        }
