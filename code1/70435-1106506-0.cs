    using Mono.Cecil;
    
    // ..
    
    var assembly = AssemblyFactory.GetAssembly ("Foo.Bar.dll");
    var module = assembly.MainModule;
    
    bool references_file = module.TypeReferences.Contains ("System.IO.File");
