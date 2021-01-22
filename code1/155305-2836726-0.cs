    // get the assembly containing the repos
    var assembly = Assembly.GetExecutingAssembly();
    // get all repository types (classes whose name end with "Repository")
    var types = assembly.Types( Flags.PartialNameMatch, "Repository" ).Where( t => t.IsClass );
    // configure StructureMap for the found repos
    foreach( Type repoType in types )
    {
        Type entityType = assembly.Type( repoType.Name.Replace( "Repository", "" );
        // define the generic interface-based type to associate with the concrete repo type
        Type genericRepoType = typeof(IRepository).MakeGenericType( entityType );
        ObjectFactory.Configure( x => x.For( RequestedType( genericRepoType ) ).Use( repoType ) );
    }
