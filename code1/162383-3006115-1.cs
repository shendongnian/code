    static StringBuilder CreateCSV<T>( IEnumerable<T> data )
    {
    	StringBuilder builder = new StringBuilder();
    	var properties = typeof( T ).GetProperties();
    
    	foreach ( var prop in properties )
    	{	
    		builder.Append( prop.Name ).Append( ", " );
    	}
        builder.Remove( builder.Length - 2, 2 ).AppendLine();
    
    	foreach ( var row in data )
    	{
    		foreach ( var prop in properties )
    		{
    			builder.Append( prop.GetValue( row, null ) ).Append( ", " );
    		}
    
    		builder.Remove( builder.Length - 2, 2 ).AppendLine();
    	}
    
    	return builder;
    }
