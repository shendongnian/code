    private void
       DoRemoteUpdate( string assemblyPath, string className )
    { 
       Assembly assembly   = Assembly.Load(assemblyPath); 
       Type     objectType = assembly.GetType(className); 
    
       remoteAssembly = (IRemote)Activator.CreateInstance(objectType); 
       remoteAssembly.Update(); 
    }
