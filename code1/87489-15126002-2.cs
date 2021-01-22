    /// <summary>
    /// Verifies that a property was read on the mock
    /// </summary>
    public static void VerifyGet<T>(this Mock<T> mockedObject, string propertyName) where T : class
    {
        var property = typeof(T).GetProperty(propertyName);
        if (property == null)
            throw new ArgumentException(string.Format("No property by the name '{0}' was found on '{1}'.", propertyName, typeof(T).Name));
    
        // getPropFuncExpression = obj => obj.propertyName;        
        var parameterExpression = Expression.Parameter(typeof(T), typeof(T).Name);
        var propertyExpression = Expression.Property(parameterExpression, property);
        var getPropFuncExpression = Expression.Lambda(propertyExpression, parameterExpression);
        var verifyGet = mockedObject.GetType().GetMethods().Single(m => m.Name == "VerifyGet" && m.GetParameters().Length == 1);
        verifyGet.MakeGenericMethod(property.PropertyType).Invoke(mockedObject, new object[] { getPropFuncExpression });
    }
