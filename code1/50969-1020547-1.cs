    var assemblies = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .Where(a => !a.IsDynamic)
                                .Select(a => a.Location);   
                       
      cp.ReferencedAssemblies.Add(assemblies.ToArray());
        
