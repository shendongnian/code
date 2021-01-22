    //add more .Net BCL names as necessary
    var systemNames = new List<AssemblyName>
    {
    new AssemblyName ("mscorlib, Version=4.0.0.0, Culture=neutral, " +
                      "PublicKeyToken=b77a5c561934e089"),
    new AssemblyName ("System.Core, Version=4.0.0.0, Culture=neutral, "+
                      "PublicKeyToken=b77a5c561934e089")
    };
    var obj = GetObjectToTest();
    var objAN = new AssemblyName(obj.GetType().Assembly.FullName);
    bool isSystemAssembly = systemNames.Any(
            n =>  n.Name == objAN.Name 
               && n.GetPublicKeyToken().SequenceEqual(objAN.GetPublicKeyToken()));
