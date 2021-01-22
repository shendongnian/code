    public void LoadModules()
    {
       // ...
    
       Type modT = Type.GetType(mod.ModuleType);
       if (InheritsFromInterface(modT, typeof(IModule))
       {
          IModule ob = (IModule)Activator.CreateInstance(modT);   
           // ...
       }
    }
    public bool InheritsFromInterface(Type inheritor, Type interface)
    {
        Type result = inheritor.GetInterface(interface.FullName);
        return result != null;
    }
