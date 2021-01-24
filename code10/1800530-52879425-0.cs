    public static void CollectionRefresh<T>(this ObservableCollection<T> collection, List<T> items)
    {
	   //Method Content
	
	   PropertyInfo[] properties = typeof(T).GetProperties();
	   
       foreach(PropertyInfo property in properties)
       {
    	  if (property.PropertyType.IsGenericType && typeof(ObservableCollection<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
    	  {
            MethodInfo refreshMethod = property.PropertyType.GetMethod("CollectionRefresh");
    
            var instanceT1 = Expression.Parameter(typeof(T), "otherT1");
            var instanceT2 = Expression.Parameter(typeof(T), "otherT2");
            var prop1 = Expression.Call(instanceT1, property.GetMethod);
            var prop2 = Expression.Call(instanceT2, property.GetMethod);
            var collection1 = Expression.Convert(prop1, property.PropertyType);
            var collection2 = Expression.Convert(prop2, property.PropertyType);
            var refresh = Expression.Call(collection1, refreshMethod, collection2);
            var lambda = Expression.Lambda<Action<T, T>>(refresh, instanceT1, instanceT2);
            Action<T, T> func = lambda.Compile();
            func(oldCollection, newList);
    	  }
       }
	
	   //Method Content
    }
