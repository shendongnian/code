    Assembly assembly = Assembly.LoadFile(@"C:\dyn.dll");
    Type     type     = assembly.GetType("TestRunner");
    var      obj      = Activator.CreateInstance(type);
    // Alternately you could get the MethodInfo for the TestRunner.Run method
    type.InvokeMember("Run", 
                      BindingFlags.Default | BindingFlags.InvokeMethod, 
                      null,
                      obj,
                      null);
