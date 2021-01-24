    public static List<T> GetOriginalList<T>(this IEnumerable<T> whereSource)
    {
		var type = whereSource.GetType();
		var sourceField = type.GetField("source", 
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.GetField);
		
		return sourceField as List<T>;
    }
    public static MyBindingList<T> ToBindingList<T>(this IEnumerable<T> container)
    {            
        var returnVal = container as MyBindingList<T>;
        if (returnVal != null)
            return returnVal;                
    
        return new MyBindingList<T>(container.GetOriginalList<T>());
    }
