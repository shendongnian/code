    private static object CollectionXmlNodeListToObject(System.Type collectionType)
    {
        // T
        Type containedType = collectionType.GetTypeInfo().GenericTypeArguments[0];
        // List<T>
        Type interimListType = typeof(List<>).MakeGenericType(containedType);
        // IEnumerable<T>
        Type ienumerableType = typeof(IEnumerable<>).MakeGenericType(containedType);
        IList interimList = Activator.CreateInstance(interimListType) as IList;
        interimList.Add(null);
        interimList.Add(null);
        interimList.Add(null);
        interimList.Add(null);
       
        // If we can directly assign the interim list, do so
        if (collectionType == interimListType || collectionType.IsAssignableFrom(interimListType))
        {
            return interimList;
        }
        // Try to get the IEnumerable<T> constructor and use that to construct the collection object
        var constructor = collectionType.GetConstructor(new Type[] { ienumerableType });
        if (constructor != null)
        {
            return constructor.Invoke(new object[] { interimList });
        }
        else
        {
            throw new NotImplementedException();
        }
    }   
