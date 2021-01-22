        protected static string GetPropertyName<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
        {
            if (expression.NodeType == ExpressionType.Lambda && expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                PropertyInfo prop = (expression.Body as MemberExpression).Member as PropertyInfo;
                if (prop != null)
                {
                    return prop.Name;
                }
            }
            throw new ArgumentException("expression", "Not a property expression");
        }
