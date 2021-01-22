Start
    var allFiltered= Filter(AllCustomer, "Name", "Moumit");
    public static List<T> Filter<T>(this List<T> Filterable, string PropertyName, object ParameterValue)
    {
        ConstantExpression c = Expression.Constant(ParameterValue);
        ParameterExpression p = Expression.Parameter(typeof(T), "xx");
        MemberExpression m = Expression.PropertyOrField(p, PropertyName);
        var Lambda = Expression.Lambda<Func<T, Boolean>>(Expression.Equal(c, m), new[] { p });
        Func<T, Boolean> func = Lambda.Compile();
        return Filterable.Where(func).ToList();
    }
One More
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
    
Make it more expandable
    string multiCommaSeparatedPropertyNames=GetMultiplePropertyName<Property.Customer>(c => c.CustomerId, c => c.AuthorizationStatus)
    public static string GetMultiplePropertyName<T>(params Expression<Func<T, object>>[] expressions)
    {
            string[] propertyNames = new string[expressions.Count()];
            for (int i = 0; i < propertyNames.Length; i++)
            {
                propertyNames[i] = GetPropertyName(expressions[i]);
            }
            return propertyNames.Join();
    }
