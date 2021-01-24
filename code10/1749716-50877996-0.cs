    // Crate a new assenbly
    var assembly = AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("Test", new Version()), "Test", ModuleKind.Dll);
    var module = assembly.MainModule;
    var testClassType = new TypeDefinition(
        "TestNamespace",
        "TestClass",
        TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed,
        module.ImportReference(typeof(object)));
    module.Types.Add(testClassType);
    var assignMethod = new MethodDefinition(
        "Assign",
        MethodAttributes.Public | MethodAttributes.Static,
        module.ImportReference(typeof(void)));
    assignMethod.Parameters.Add(new ParameterDefinition("arr", ParameterAttributes.None, module.ImportReference(typeof(byte[]))));
    testClassType.Methods.Add(assignMethod);
    // Get ILProcessor for the method body
    var ilProcessor = assignMethod.Body.GetILProcessor();
            
    ilProcessor.Body.Variables.Add(new VariableDefinition(module.ImportReference(typeof(byte).MakePointerType())));
    // THIS IS WHAT YOU WANT!
    // using Mono.Cecil.Rocks or new PinnedType(module.ImportReference(...))
    ilProcessor.Body.Variables.Add(new VariableDefinition(module.ImportReference(typeof(byte[])).MakePinnedType()));
    var instrLabelA = ilProcessor.Create(OpCodes.Ldc_I4_0);
    var instrLabelB = ilProcessor.Create(OpCodes.Ldloc_1);
    var instrLabelC = ilProcessor.Create(OpCodes.Ldloc_0);
    ilProcessor.Emit(OpCodes.Ldarg_0);
    ilProcessor.Emit(OpCodes.Dup);
    ilProcessor.Emit(OpCodes.Stloc_1);
    ilProcessor.Emit(OpCodes.Brfalse_S, instrLabelA);
    ilProcessor.Emit(OpCodes.Ldloc_1);
    ilProcessor.Emit(OpCodes.Ldlen);
    ilProcessor.Emit(OpCodes.Conv_I4);
    ilProcessor.Emit(OpCodes.Brtrue_S, instrLabelB);
    ilProcessor.Append(instrLabelA);
    ilProcessor.Emit(OpCodes.Conv_U);
    ilProcessor.Emit(OpCodes.Stloc_0);
    ilProcessor.Emit(OpCodes.Br_S, instrLabelC);
    ilProcessor.Append(instrLabelB);
    ilProcessor.Emit(OpCodes.Ldc_I4_0);
    ilProcessor.Emit(OpCodes.Ldelema, module.ImportReference(typeof(byte)));
    ilProcessor.Emit(OpCodes.Conv_U);
    ilProcessor.Emit(OpCodes.Stloc_0);
    ilProcessor.Append(instrLabelC);
    ilProcessor.Emit(OpCodes.Ldc_I4, 255);
    ilProcessor.Emit(OpCodes.Stind_I1);
    ilProcessor.Emit(OpCodes.Ldnull);
    ilProcessor.Emit(OpCodes.Stloc_1);
    ilProcessor.Emit(OpCodes.Ret);
    // Because this is an executable assembly, you must define an entry point
    assembly.EntryPoint = assignMethod;
    // Save the assembly to disk
    assembly.Write(@"test.dll");
