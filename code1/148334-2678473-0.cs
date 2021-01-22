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
        method.Invoke( control, new object[] { true } );
    }
