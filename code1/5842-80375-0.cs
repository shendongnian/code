    Assembly assembly = Assembly.GetExecutingAssembly();
    List<Type> types = assembly.GetTypes();
    List<Type> childTypes = new List<Type>();
    foreach (Type type in Types) {
      foreach (Type interfaceType in type.GetInterfaces()) {
           if (interfaceType.Equals(typeof([yourinterfacetype)) {
                childTypes.Add(type)
                break;
           }
      }
    }
