    DynamicMethod method = new DynamicMethod(string.Empty, typeof(T), null,
        MethodBase.GetCurrentMethod().DeclaringType.Module);
    ILGenerator il = method.GetILGenerator();
    il.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
    il.Emit(OpCodes.Ret);
    var constructor = (ConstructorDelegate)method.CreateDelegate(typeof(ConstructorDelegate));
