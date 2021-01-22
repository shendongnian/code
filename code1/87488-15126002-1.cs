    public static class MoqExtensions
    {
       /// <summary>
       /// Verifies that a property was read on the mock
       /// </summary>
       public static void VerifyGet<T>(this Mock<T> mockedObject, string propertyName) where T : class
       {
          var property = typeof(T).GetProperty(propertyName);
          var expression = typeof(MoqExtensions).GetMethod("GetPropertyExpression", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(T), property.PropertyType).Invoke(null, new object[] { property });
          var verifyGet = mockedObject.GetType().GetMethods().Single(m => { return m.Name == "VerifyGet" && m.GetParameters().Length == 1; });
          verifyGet.MakeGenericMethod(property.PropertyType).Invoke(mockedObject, new object[] { expression });
       }
    
       private static Expression<Func<T, TProperty>> GetPropertyExpression<T, TProperty>(PropertyInfo property) where T : class
       {
          var objectParameter = Expression.Parameter(typeof(T), typeof(T).Name);
          var getProperty = Expression.Property(objectParameter, property);
          return Expression.Lambda<Func<T, TProperty>>(getProperty, objectParameter);
       }
    }
