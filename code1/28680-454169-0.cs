     var commands = new List<object>();
     foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
     {
        foreach (Type type in assembly.GetTypes())
        {
           if (type.GetInterface(typeof(ICommand).FullName) != null)
           {
              commands.Add(Activator.CreateInstance(type));
           }
        }
     }
