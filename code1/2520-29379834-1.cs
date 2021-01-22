     private IEnumerable<Type> GetTypesWithInterface(Assembly asm)
     {
          var it = typeof (IMyInterface);
          return asm.GetLoadableTypes().Where(it.IsAssignableFrom).ToList();
     }
