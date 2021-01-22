     Assembly commandAssembly = Assembly.Load("some/path")
     var commands = new List<ICommand>();
    
     foreach (Type type in commandAssembly.GetTypes())
     {
        if (type.GetInterface(typeof(ICommand).FullName) != null)
        {
           commands.Add((ICommand)Activator.CreateInstance(type));
        }
     }
