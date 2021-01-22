    public static PropertyInfo GetPropertyByPath( object obj, string propertyPath )
    {
    
    	ParameterValidation.ThrowIfNullOrWhitespace( propertyPath, "propertyPath" );
    
    	if ( obj == null ) {
    		return null;
    	}   // if
    
    	Type type = obj.GetType( );
    
    	PropertyInfo propertyInfo = null;
    	foreach ( var part in propertyPath.Split( new char[] { '.' } ) ) {
    
    		// On subsequent iterations use the type of the property
    		if ( propertyInfo != null ) {
    			type = propertyInfo.PropertyType;
    		}   // if
    
    		// Get the property at this part
    		propertyInfo = type.GetProperty( part );
    
    		// Not found
    		if ( propertyInfo == null ) {
    			return null;
    		}   // if
    
    		// Can't navigate into indexer
    		if ( propertyInfo.GetIndexParameters( ).Length > 0 ) {
    			return null;
    		}   // if
    
    	}   // foreach
    
    	return propertyInfo;
    
    }
