    ObjectFactory.Configure(x => x.Scan (
      scan =>
      {
        scan.AssembliesFromPath(Environment.CurrentDirectory 
        /*, filter=>filter.You.Could.Filter.Here*/);
    
        //scan.WithDefaultConventions(); //doesn't do it
    
        scan.With<MyScanner>();
      }
    ));
         
    ObjectFactory.GetAllInstances<PersonBase>()
     .ToList()
      .ForEach(p => 
      { Console.WriteLine(p.FirstName); } );
      
