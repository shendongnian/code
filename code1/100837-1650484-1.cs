    public Configuration AddAssembly( string assemblyName )
    {
          log.Info( "searching for mapped documents in assembly: " + assemblyName );
          Assembly assembly = null;
          try
          {
                assembly = Assembly.Load( assemblyName );
          }
          catch( Exception e )
          {
                log.Error( "Could not configure datastore from assembly", e );
                throw new MappingException( "Could not add assembly named: " + assemblyName, e );
          }
          return this.AddAssembly( assembly );
    }
