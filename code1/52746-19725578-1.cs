        public static Expression<Func<T, bool>> strToFunc<T>(string propName, string opr, string value, Expression<Func<T, bool>> expr = null)
        {
            Expression<Func<T, bool>> func = null;
            try
            {
                var prop = GetProperty<T>(propName);
                ParameterExpression tpe = Expression.Parameter(typeof(T));
                Expression left = Expression.Property(tpe, prop);
                Expression right = Expression.Convert(ToExprConstant(prop, value), prop.PropertyType);
                Expression<Func<T, bool>> innerExpr = Expression.Lambda<Func<T, bool>>(ApplyFilter(opr, left, right), tpe);
                if (expr != null)
                    innerExpr = innerExpr.And(expr);
                func = innerExpr;
            }
            catch { }
            return func;
        }
        private static Expression ToExprConstant(PropertyInfo prop, string value)
        {
            object val = null;
            switch (prop.PropertyTypeName())
            {
                case "System.Guid":
                    val = value.ToGuid();
                    break;
                default:
                    val = Convert.ChangeType(value, Type.GetType(prop.PropertyTypeName()));
                    break;
            }
            return Expression.Constant(val);
        }
        private static BinaryExpression ApplyFilter(string opr, Expression left, Expression right)
        {
            BinaryExpression InnerLambda = null;
            switch (opr)
            {
                case "==":
                case "=":
                    InnerLambda = Expression.Equal(left, right);
                    break;
                case "<":
                    InnerLambda = Expression.LessThan(left, right);
                    break;
                case ">":
                    InnerLambda = Expression.GreaterThan(left, right);
                    break;
                case ">=":
                    InnerLambda = Expression.GreaterThanOrEqual(left, right);
                    break;
                case "<=":
                    InnerLambda = Expression.LessThanOrEqual(left, right);
                    break;
                case "!=":
                    InnerLambda = Expression.NotEqual(left, right);
                    break;
                case "&&":
                    InnerLambda = Expression.And(left, right);
                    break;
                case "||":
                    InnerLambda = Expression.Or(left, right);
                    break;
            }
            return InnerLambda;
        }
        public static Expression<Func<T, TResult>> And<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, TResult>>(Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
        public static Func<T, TResult> ExpressionToFunc<T, TResult>(this Expression<Func<T, TResult>> expr)
        {
            return expr.Compile();
        }
