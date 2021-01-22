    static string GetCSharpRepresentation( Type t, bool trimArgCount ) {
        if( t.IsGenericType ) {
            string value = t.Name;
            if( trimArgCount ) {
                value = value.Substring( 0, value.IndexOf( "`" ) );
            }
    
            value += "<";
    
            var genericArgs = t.GetGenericArguments();
            for( int i = 0; i < genericArgs.Length; i++ ) {
                if( i != 0 ) value += ", ";
    
                value += GetCSharpRepresentation( genericArgs[i], trimArgCount );
            }
    
            value += ">";
    
            return value;
        }
    
        return t.Name;
    }
