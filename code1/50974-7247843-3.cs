    var assemblies = someType.Assembly.GetReferencedAssemblies().ToList();
       var assemblyLocations =  
    assemblies.Select(a => 
         Assembly.ReflectionOnlyLoad(a.FullName).Location).ToList();
    
    assemblyLocations.Add(someType.Assembly.Location);
    cp.ReferencedAssemblies.AddRange(assemblyLocations.ToArray());
