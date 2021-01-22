    var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(
        new AssemblyName(assemblyName), AssemblyBuilderAccess.Save);
    var mod = asm.DefineDynamicModule(assemblyName, fileName);        
    var type = mod.DefineType("Program",
        TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Public);
    var mainMethod = type.DefineMethod("Main",
        MethodAttributes.Public | MethodAttributes.Static);
    // ... Code for Main method and the rest ...
    type.CreateType();
    asm.SetEntryPoint(mainMethod,PEFileKinds.WindowApplication);
    asm.Save(fileName);
