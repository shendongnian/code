    public static class MoqExtensions
    {
       public static void VerifyGet<T>(this Mock<T> mockedObject, string propertyName, Times times) where T : class
       {
          var property = typeof(T).GetProperty(propertyName);
          var expression = typeof(MoqExtensions).GetMethod("GetExpression", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeof(T), property.PropertyType).Invoke(null, new object[] { property });
          var verfifyGet = mockedObject.GetType().GetMethods().Single(m => { var param = m.GetParameters(); return m.Name == "VerifyGet" && param.Length == 2 && param[1].ParameterType == typeof(Times); });
          verfifyGet.MakeGenericMethod(property.PropertyType).Invoke(mockedObject, new object[] { expression, times });
       }
    
       private static Expression<Func<TClass, TProperty>> GetExpression<TClass, TProperty>(PropertyInfo property) where TClass : class
       {
          var entityParameter = Expression.Parameter(typeof(TClass), "param");
          var getProperty = Expression.Property(entityParameter, property);
          return Expression.Lambda<Func<TClass, TProperty>>(getProperty, entityParameter);
       }
    }
