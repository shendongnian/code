    string singlePropertyName=GetPropertyName((Property.Customer p) => p.Name);
    public static string GetPropertyName<T, U>(Expression<Func<T, U>> expression)
    {
            MemberExpression body = expression.Body as MemberExpression;
            // if expression is not a member expression
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)expression.Body;
                body = ubody.Operand as MemberExpression;
            }
            return string.Join(".", body.ToString().Split('.').Skip(1));
    }
    
