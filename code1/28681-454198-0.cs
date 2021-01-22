     Assembly commandAssembly = Assembly.Load("some/path")
     var commands = new List<object>();
    
     foreach (Type type in commandAssembly.GetTypes())
     {
        if (type.GetInterface(typeof(ICommand).FullName) != null)
        {
           commands.Add(Activator.CreateInstance(type));
        }
     }
