    static string GetCSharpRepresentation( Type t, bool trimArgCount ) {
        if( t.IsGenericType ) {
            var genericArgs = t.GetGenericArguments().ToList();
    
            return GetCSharpRepresentation( t, trimArgCount, genericArgs );
        }
    
        return t.Name;
    }
    
    static string GetCSharpRepresentation( Type t, bool trimArgCount, List<Type> availableArguments ) {
        if( t.IsGenericType ) {
            string value = t.Name;
            if( trimArgCount && value.IndexOf("`") > -1 ) {
                value = value.Substring( 0, value.IndexOf( "`" ) );
            }
    
            if( t.DeclaringType != null ) {
                // This is a nested type, build the nested type first
                value = GetCSharpRepresentation( t.DeclaringType, trimArgCount, availableArguments ) + "+" + value;
            }
    
            // Build the type arguments (if any)
            string argString = "";
            var thisTypeArgs = t.GetGenericArguments();
            for( int i = 0; i < thisTypeArgs.Length && availableArguments.Count > 0; i++ ) {
                if( i != 0 ) argString += ", ";
    
                argString += GetCSharpRepresentation( availableArguments[0], trimArgCount );
                availableArguments.RemoveAt( 0 );
            }
    
            // If there are type arguments, add them with < >
            if( argString.Length > 0 ) {
                value += "<" + argString + ">";
            }
    
            return value;
        }
    
        return t.Name;
    }
