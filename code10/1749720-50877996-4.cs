    var ilProcessor = assignMethod.Body.GetILProcessor();
    // THIS IS WHAT YOU WANT!
    // using Mono.Cecil.Rocks or new PinnedType(module.ImportReference(...))
    ilProcessor.Body.Variables.Add(new VariableDefinition(module.ImportReference(typeof(byte)).MakePinnedType()));
    ilProcessor.Emit(OpCodes.Ldarg_0);
    ilProcessor.Emit(OpCodes.Ldc_I4_0);
    ilProcessor.Emit(OpCodes.Ldelema, module.ImportReference(typeof(byte)));
    ilProcessor.Emit(OpCodes.Stloc_0);
    ilProcessor.Emit(OpCodes.Ldloc_0);
    ilProcessor.Emit(OpCodes.Conv_U);
    ilProcessor.Emit(OpCodes.Ldc_I4, 255);
    ilProcessor.Emit(OpCodes.Stind_I1);
    ilProcessor.Emit(OpCodes.Ldc_I4_0);
    ilProcessor.Emit(OpCodes.Conv_U);
    ilProcessor.Emit(OpCodes.Stloc_0);
    ilProcessor.Emit(OpCodes.Ret);
