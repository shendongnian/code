    static void LoadWithIntercept(string assemblyName) {
      var domain = AppDomain.CurrentDomain;
      domain.AssemblyResolve += MyInterceptMethod;
      try {
        Assembly.ReflectionOnlyLoad(assemblyName);
      } finally {
        domain.AssemblyResolve -= MyInterceptMethod;
      }
    }
    
    private static Assembly MyInterceptMethod(object sender, ResolveEventArgs e) {
     // do custom code here 
    }
