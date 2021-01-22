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
