        private static Assembly AppDomain_AssemblyResolve( object sender, ResolveEventArgs args )
            {
                if( args.Name.Contains( "YourComponent" ) )
                {           
                    using( var resource = new MemoryStream( Resources.YourComponent ) )
                        return Assembly.Load( resource.GetBuffer() );
                }
    
                return null;
            }
