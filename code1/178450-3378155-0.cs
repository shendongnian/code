    // Define the assembly and the module.
    AppDomain appDomain = AppDomain.CurrentDomain;
    AssemblyName assemblyName = new AssemblyName("EmittedAssembly");
    AssemblyBuilder assembly = appDomain.DefineDynamicAssembly(
    assemblyName, AssemblyBuilderAccess.RunAndSave);
    // An assembly is made up of executable modules. For a single-module
    // assembly, the module name and file name are the same as the 
    // assembly name. 
    ModuleBuilder module = assembly.DefineDynamicModule(
    assemblyName.Name, assemblyName.Name + ".dll");
    /////////////////////////////////////////////////////////////////////
    // Declare the types (classes).
    // 
    // Declare the class "ClassA"
    TypeBuilder classA = module.DefineType("ClassA", TypeAttributes.Public);
    // Declare the class "ClassB"
    TypeBuilder classB = module.DefineType("ClassB", TypeAttributes.Public);
    // Define the fields stringField, classBField
    FieldBuilder stringField = classA.DefineField("stringField",
    typeof(string), FieldAttributes.Private);
    FieldBuilder classBField = classA.DefineField("classBField",
    classB, FieldAttributes.Public);
    /////////////////////////////////////////////////////////////////////
    // Define the property ClassBProperty
    PropertyBuilder classBProperty = classA.DefineProperty(
        "ClassBProperty", PropertyAttributes.None, classB, null);
    
    // The special set of attributes for the property set&get methods
    MethodAttributes getSetAttr = MethodAttributes.Public |
        MethodAttributes.SpecialName | MethodAttributes.HideBySig;
    
    // Define the "get" accessor method for ClassBProperty
    MethodBuilder classBGetProp = classA.DefineMethod(
        "get_ClassBProperty", getSetAttr, classB, Type.EmptyTypes);
    ILGenerator classBGetIL = classBGetProp.GetILGenerator();
    classBGetIL.Emit(OpCodes.Ldarg_0);
    classBGetIL.Emit(OpCodes.Ldfld, classBField);
    classBGetIL.Emit(OpCodes.Ret);
    
    // Define the "set" accessor method for ClassBProperty
    MethodBuilder classBSetProp = classA.DefineMethod(
        "set_ClassBProperty", getSetAttr, null, new Type[] { classB });
    ILGenerator sampleSetIL = classBSetProp.GetILGenerator();
    sampleSetIL.Emit(OpCodes.Ldarg_0);
    sampleSetIL.Emit(OpCodes.Ldarg_1);
    sampleSetIL.Emit(OpCodes.Stfld, classBField);
    sampleSetIL.Emit(OpCodes.Ret);
    
    // Map the get&set methods to PropertyBuilder
    classBProperty.SetGetMethod(classBGetProp);
    classBProperty.SetSetMethod(classBSetProp);
    /////////////////////////////////////////////////////////////////////
    // Define a method that uses the classBField
    MethodBuilder classAMethod = classA.DefineMethod("ClassAMethod", 
        MethodAttributes.Public);
    
    // Define the list generics and ienumerable generic
    Type listOf = typeof(List<>);
    Type enumOf = typeof(IEnumerable<>);
    Type listOfClassA = listOf.MakeGenericType(classA);
    Type enumOfClassA = enumOf.MakeGenericType(classA);
    
    // Define the method, ClassBMethod, for ClassB
    MethodBuilder classBMethod = classB.DefineMethod("ClassBMethod", 
        MethodAttributes.Public, typeof(void), new Type[] { listOfClassA });
    classBMethod.DefineParameter(1, ParameterAttributes.None, "list");
    
    // Write the body of ClassAMethod that calls ClassBMethod
    ILGenerator ilgenA = classAMethod.GetILGenerator();
    ilgenA.Emit(OpCodes.Nop);
    ilgenA.Emit(OpCodes.Ldarg_0);
    ilgenA.Emit(OpCodes.Ldfld, classBField);
    ilgenA.Emit(OpCodes.Ldnull);
    ilgenA.Emit(OpCodes.Callvirt, classBMethod);
    ilgenA.Emit(OpCodes.Ret);
    /////////////////////////////////////////////////////////////////////
    // Create the types.
    // 
    
    classA.CreateType();
    classB.CreateType();    
    
    /////////////////////////////////////////////////////////////////////
    // Save the assembly.
    // 
    
    assembly.Save(assemblyName.Name + ".dll");
