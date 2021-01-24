     Assembly assembly = Assembly.LoadFrom("Path");
     var results = assembly.GetTypes();
     Type type = assembly.GetType("Library.MyVariables");
     dynamic instanceOfMyType = Activator.CreateInstance(type);
     Console.Write(instanceOfMyType.TestProp);
