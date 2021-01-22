    var assembly = Assembly.GetExecutingAssembly(); //here you would retrieve the assembly you wish to search.
    
    foreach ( var type in assembly.GetTypes() )
    {
    	if ( type.GetInterface( "IMyInterface", true ) != null )
    	{
    		var instance = Activator.CreateInstance( type ) As IMyInterface;
    		instance.MethodIWantToCall();
    	}
    }
