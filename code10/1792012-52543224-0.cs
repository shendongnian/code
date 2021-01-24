    // create a TypeBuilder
    var relayGenBuilder = module.DefineType("RelayGen", TypeAttributes.Public, typeof(DaemonBase));
    var methodAttributes = MethodAttributes.Public
        | MethodAttributes.Virtual
        | MethodAttributes.HideBySig;
    var returnType = typeof(Task<>).MakeGenericType(typeof(Pair));
    var parameters = new []
    {
        typeof(IEnumerable<>).MakeGenericType(typeof(string)),
        typeof(Nullable<>).MakeGenericType(typeof(TimeSpan))
    };
    
    // cteate a new method
    var popAsync = relayGenBuilder.DefineMethod("BLPopAsync", 
        methodAttributes, 
        CallingConventions.HasThis,
        returnType,
        parameters); 
 
    var ilGen = popAsync.GetILGenerator();
    var falseLabel = ilGen.DefineLabel();
    var isTran = typeof(DaemonBase).GetField("IsTransaction");
    var writeLine = typeof(Console).GetMethod("WriteLine", new[] {typeof(string)});
    ilGen.Emit(OpCodes.Ldarg_0);
    ilGen.Emit(OpCodes.Ldfld, isTran);
    ilGen.Emit(OpCodes.Brfalse_S, falseLabel);
    // if (IsTransaction)
        ilGen.Emit(OpCodes.Ldstr, "IsTransaction equals true");
        ilGen.EmitCall(OpCodes.Call, writeLine, null);
        ilGen.Emit(OpCodes.Ldnull);
        ilGen.Emit(OpCodes.Ret);
    // else
        ilGen.MarkLabel(falseLabel);
        ilGen.Emit(OpCodes.Ldnull);
        ilGen.Emit(OpCodes.Ret);
