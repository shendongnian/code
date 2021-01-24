    string myClass = "Car";
    var types = Assembly.GetExecutingAssembly().GetTypes().ToList();
    var myType = types.FirstOrDefault(i => i.IsClass && i.Name == myClass);
    var instance  = Activator.CreateInstance((Type) myType);
    Console.Write(instance.ToString());
