    var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
      new AssemblyName("Test"), 
      AssemblyBuilderAccess.RunAndSave); // allow run & save
    
    var moduleBuilder = assembly.DefineDynamicModule("Test",
      "Test.dll"); // specify a file name where module will be stored
      
    ...
    
    var baseType = baseTypeBuilder.CreateType();
    var derivedType = derivedTypeBuilder.CreateType();
    assembly.Save("Test.dll");
