    string root = string.Empty;
    Assembly ass = Assembly.GetAssembly( typeof( MyApp.MyClass ) );
    if ( ass != null )
    {
       root = ass.Location;
    }
