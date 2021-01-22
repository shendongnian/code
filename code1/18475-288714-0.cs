    public static bool IsHidingMember( this PropertyInfo self )
    {
    	Type baseType = self.DeclaringType.BaseType;
    	PropertyInfo baseProperty = baseType.GetProperty( self.Name, self.PropertyType );
    
    	if ( baseProperty == null )
    	{
    		return false;
    	}
    
    	if ( baseProperty.DeclaringType == self.DeclaringType )
    	{
    		return false;
    	}
    
    	var baseMethodDefinition = baseProperty.GetGetMethod().GetBaseDefinition();
    	var thisMethodDefinition = self.GetGetMethod().GetBaseDefinition();
    
    	return baseMethodDefinition.DeclaringType != thisMethodDefinition.DeclaringType;
    }
