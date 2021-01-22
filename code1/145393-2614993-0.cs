    var assemblyName = new AssemblyName
                           {
                               Name = "Whatever",
                               CodeBase = Directory.GetCurrentDirectory()
                           };
    var assemblyBuilder = AppDomain.CurrentDomain
        .DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);
    var moduleBuilder = assemblyBuilder.DefineDynamicModule(
        "WhateverModule", "Whatever.dll");
    var typeBuilder = 
                     moduleBuilder.DefineType("WhateverType", TypeAttributes.Public);
    var type = typeBuilder.CreateType();
    assemblyBuilder.Save("Whatever.dll");
    
    var assembly = Assembly.LoadFrom("Whatever.dll");
    var codeBase = assembly.CodeBase; // this won't throw exception
