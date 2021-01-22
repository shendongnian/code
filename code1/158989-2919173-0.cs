    if (type.IsSubclassOf(typeof(CodeObject))) {
    	var baseMethod = typeof(Codes).GetMethod("Fetch<>", BindingFlags.Static | BidingFlags.Public, null, new Type[] {typeof(string)}, null);
    	if (baseMethod != null) {
    		var genericMethod = baseMethod.MakeGenericMethod(type);
    		if (genericMethod != null)
    			return (T)genericMethod.Invoke(null, new string[] { val });
    	}
    }
