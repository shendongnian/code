    Assembly asm = Assembly.GetExecutingAssembly();
    string classname = "MyNamespace.MyClass";
    Type classtype = asm.GetType(classname);
    
    // Constructor without parameters
    IMyInterface instance = (IMyInterface)Activator.CreateInstance(classtype);
    // With parameters (eg. first: string, second: int):
    IMyInterface instance = (IMyInterface)Activator.CreateInstance(classtype, 
                            new object[]{
                                (object)"param1",
                                (object)5
                            });
