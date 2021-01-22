        MethodInfo countMethodInfo = typeof (System.Linq.Enumerable).GetMethods().Single(
            method => method.Name == "Count" && method.IsStatic && method.GetParameters().Length == 1);
        PropertyInfo[] properties = typeof(MyCollections).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Type propertyType = property.PropertyType;
            if (propertyType.IsGenericType)
            {
                Type genericType = propertyType.GetGenericTypeDefinition();
                if (genericType == typeof(IEnumerable<>))
                {
                    // access the collection property
                    object collection = property.GetValue(obj, null);
                    // access the type of the generic collection
                    Type genericArgument = propertyType.GetGenericArguments()[0];
                    // make a generic method call for System.Linq.Enumerable.Count<> for the type of this collection
                    MethodInfo localCountMethodInfo = countMethodInfo.MakeGenericMethod(genericArgument);
                    // invoke Count method (this fails)
                    object count = localCountMethodInfo.Invoke(null, new object[] {collection});
                    System.Diagnostics.Debug.WriteLine("{0}: {1}", genericArgument.Name, count);
                }
            }
        }
