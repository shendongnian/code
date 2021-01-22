    Assembly asm = Assembly.GetExecutingAssembly();
    foreach (Type type in asm.GetTypes())
    {
     if(type.GetInterface(typeof(IDisposable).FullName)  != null)
     {
      // Store the list somewhere
     }
    }
