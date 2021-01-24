    if (IsList(obj))
    {
        List<object> objs = ((IEnumerable)obj).Cast<object>().ToList();
    	Type containedType = type.GenericTypeArguments.First();
    	return objs.Select(item => Convert.ChangeType(item, containedType)).ToList();
    }
