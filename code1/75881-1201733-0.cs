    private Assembly myDynamicAssembly = null;
    
    protected void Application_Start( object sender, EventArgs e )
    {
          myDynamicAssembly = Assembly.LoadFrom( Server.MapPath( "MyLocation/MyAssembly.dll" ) );
    
          AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler( CurrentDomain_AssemblyResolve );
    }
    
    Assembly CurrentDomain_AssemblyResolve( object sender, ResolveEventArgs args )
    {
          if ( args.Name == "MyAssembly" )
          {
    	       return myDynamicAssembly;
          }
    
          return null;
    }
