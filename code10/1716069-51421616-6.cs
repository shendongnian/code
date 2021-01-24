    private static IEnumerable<UniqueKeyAttribute> GetUniqueKeyAttributes(IMutableEntityType entityType, IMutableProperty property)
    {
    	if (entityType == null)
    	{
    		throw new ArgumentNullException(nameof(entityType));
    	}
    	else if (entityType.ClrType == null)
    	{
    		throw new ArgumentNullException(nameof(entityType.ClrType));
    	}
    	else if (property == null)
    	{
    		throw new ArgumentNullException(nameof(property));
    	}
    	else if (property.Name == null)
    	{
    		throw new ArgumentNullException(nameof(property.Name));
    	}
    	var propInfo = entityType.ClrType.GetProperty(
    		property.Name,
    		BindingFlags.NonPublic |
    		BindingFlags.Public |
    		BindingFlags.Static |
    		BindingFlags.Instance |
    		BindingFlags.DeclaredOnly);
    	if (propInfo == null)
    	{
    		return null;
    	}
    	return propInfo.GetCustomAttributes<UniqueKeyAttribute>();
    }
