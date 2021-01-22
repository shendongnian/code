    void AddValue<T>(object targetList, T valueToAdd)
    {
    	var addMethod = targetList.GetType().GetMethod("Add");
    	addMethod.Invoke(targetList, new[] { valueToAdd } as object[]);
    }
    
    var listType = typeof(List<>).MakeGenericType(new[] { dynamicType }); // dynamicType is the type you want
    var list = Activator.CreateInstance(listType);
    
    AddValue(list, 5);
