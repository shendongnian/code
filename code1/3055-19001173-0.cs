    public static class ObjectExtensions 
    {
    	public static string PropertyName<TModel, TProperty>( this TModel @this, Expression<Func<TModel, TProperty>> expr )
    	{
    		Type source = typeof(TModel);
    		MemberExpression member = expr.Body as MemberExpression;
    
    		if (member == null)
    			throw new ArgumentException(String.Format(
    				"Expression '{0}' refers to a method, not a property",
    				expr.ToString( )));
    
    		PropertyInfo property = member.Member as PropertyInfo;
    
    		if (property == null)
    			throw new ArgumentException(String.Format(
    				"Expression '{0}' refers to a field, not a property",
    				expr.ToString( )));
    
    		if (source != property.ReflectedType ||
    			!source.IsSubclassOf(property.ReflectedType) ||
    			!property.ReflectedType.IsAssignableFrom(source))
    			throw new ArgumentException(String.Format(
    				"Expression '{0}' refers to a property that is not a member of type '{1}'.",
    				expr.ToString( ),
    				source));
    
    		return property.Name;
    	}
    }
