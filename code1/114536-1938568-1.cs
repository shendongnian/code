    public void TestAllFoos() {
       foreach(string assembly in Directory.GetFiles(assemblyPath, "*.dll", SearchOptions.All) {
          Assembly currentAssembly = Assembly.LoadAssembly(assembly);
          
          foreach(Type internalTypes in currentAssembly.GetTypes()) {
             if (internalTypes.IsAssignableFrom(IFoo) && !(internalTypes is IFoo)) {
                IFoo fooType = AppActivator.CreateInstance(internalTypes);
    
                GenericIFooTest(fooType);
             }
          }
       }
    }
