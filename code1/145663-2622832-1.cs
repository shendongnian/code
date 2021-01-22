    const string methodName = "Boolean SequenceEqual[TSource](System.Collections.Generic.IEnumerable`1[TSource], System.Collections.Generic.IEnumerable`1[TSource])";
    
    var sequenceEqual = 
            typeof(Enumerable)
            .GetMethods()
            .First(m => m.ToString() == methodName);
    foreach (var prop in typeof(TModelType).GetProperties())
    {        
        var expectedValue = prop.GetValue(expected, null);
        var actualValue = prop.GetValue(actual, null);
    
        foreach (var item in a.GetType().GetInterfaces())
        {
    	    if (item.IsGenericType && item.Name.Contains("IEnumerable`1"))
    	    {
    		    Assert.IsTrue(
                    (bool)sequenceEqual.MakeGenericMethod(
                        item.GetGenericArguments()[0]
                    ).Invoke(null, new[] { expectedValue, actualValue })
                );				
    	    }
        }
    }
