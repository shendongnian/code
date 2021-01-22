        /// <summary>
        ///     A method to create an expression dynamically given a generic entity, and a propertyName, operator and value.
        /// </summary>
        /// <typeparam name="TEntity">
        ///     The class to create the expression for. Most commonly an entity framework entity that is used
        ///     for a DbSet.
        /// </typeparam>
        /// <param name="propertyName">The string value of the property.</param>
        /// <param name="op">An enumeration type with all the possible operations we want to support.</param>
        /// <param name="value">A string representation of the value.</param>
        /// <param name="valueType">The underlying type of the value</param>
        /// <returns>An expression that can be used for querying data sets</returns>
        private static Expression<Func<TEntity, bool>> CreateDynamicExpression<TEntity>(string propertyName,
            Operator op, string value, Type valueType)
        {
            Type type = typeof(TEntity);
            object asType = AsType(value, valueType);
            var p = Expression.Parameter(type, "x");
            var property = Expression.Property(p, propertyName);
            MethodInfo method;
            Expression q;
            switch (op)
            {
                case Operator.Gt:
                    q = Expression.GreaterThan(property, Expression.Constant(asType));
                    break;
                case Operator.Lt:
                    q = Expression.LessThan(property, Expression.Constant(asType));
                    break;
                case Operator.Eq:
                    q = Expression.Equal(property, Expression.Constant(asType));
                    break;
                case Operator.Le:
                    q = Expression.LessThanOrEqual(property, Expression.Constant(asType));
                    break;
                case Operator.Ge:
                    q = Expression.GreaterThanOrEqual(property, Expression.Constant(asType));
                    break;
                case Operator.Ne:
                    q = Expression.NotEqual(property, Expression.Constant(asType));
                    break;
                case Operator.Contains:
                    method = typeof(string).GetMethod("Contains", new[] {typeof(string)});
                    q = Expression.Call(property, method ?? throw new InvalidOperationException(),
                        Expression.Constant(asType, typeof(string)));
                    break;
                case Operator.StartsWith:
                    method = typeof(string).GetMethod("StartsWith", new[] {typeof(string)});
                    q = Expression.Call(property, method ?? throw new InvalidOperationException(),
                        Expression.Constant(asType, typeof(string)));
                    break;
                case Operator.EndsWith:
                    method = typeof(string).GetMethod("EndsWith", new[] {typeof(string)});
                    q = Expression.Call(property, method ?? throw new InvalidOperationException(),
                        Expression.Constant(asType, typeof(string)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(op), op, null);
            }
            return Expression.Lambda<Func<TEntity, bool>>(q, p);
        }
        /// <summary>
        ///     Extract this string value as the passed in object type
        /// </summary>
        /// <param name="value">The value, as a string</param>
        /// <param name="type">The desired type</param>
        /// <returns>The value, as the specified type</returns>
        private static object AsType(string value, Type type)
        {
            //TODO: This method needs to be expanded to include all appropriate use cases
            string v = value;
            if (value.StartsWith("'") && value.EndsWith("'"))
                v = value.Substring(1, value.Length - 2);
            if (type == typeof(string))
                return v;
            if (type == typeof(DateTime))
                return DateTime.Parse(v);
            if (type == typeof(DateTime?))
                return DateTime.Parse(v);
            if (type == typeof(int))
                return int.Parse(v);
            if (type == typeof(int?)) return int.Parse(v);
            throw new ArgumentException("A filter was attempted for a field with value '" + value + "' and type '" +
                                        type + "' however this type is not currently supported");
        }
