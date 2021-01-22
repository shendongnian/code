    private static void CreateControls( Control control )
    {
    	CreateControl( control );
    	foreach ( Control subcontrol in control.Controls )
    	{
    		CreateControl( subcontrol );
    	}
    }
    private static void CreateControl( Control control )
    {
    	var method = control.GetType().GetMethod( "CreateControl", BindingFlags.Instance | BindingFlags.NonPublic );
    	var parameters = method.GetParameters();
    	Debug.Assert( parameters.Length == 1, "Looking only for the method with a single parameter" );
    	Debug.Assert( parameters[0].ParameterType == typeof ( bool ), "Single parameter is not of type boolean" );
    
    	method.Invoke( control, new object[] { true } );
    }
