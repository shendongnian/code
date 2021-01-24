    var ctorBuilder2 = test.DefineConstructor(MethodAttributes.Public,
        CallingConventions.Standard, new Type[0]);
    var generator = ctorBuilder2.GetILGenerator();
    generator.Emit(OpCodes.Ldarg_0);
    generator.Emit(OpCodes.Ldstr, "arg1");
    generator.Emit(OpCodes.Call, ctor1);
    generator.Emit(OpCodes.Ret);
