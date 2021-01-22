    private static Func<object, object> BuildAccessor(MethodInfo method)
    {
        DynamicMethod dm = new DynamicMethod(method.DeclaringType.Name + method.Name + "MethodAccessor", typeof(object), new Type[] { typeof(object) }, method.DeclaringType);
        var gen = dm.GetILGenerator();
        if (!method.IsStatic)
        {
            gen.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            gen.Emit(System.Reflection.Emit.OpCodes.Castclass, method.DeclaringType);
        }
        if (method.IsVirtual && !method.IsFinal)
            gen.EmitCall(System.Reflection.Emit.OpCodes.Callvirt, method, null);
        else
            gen.EmitCall(System.Reflection.Emit.OpCodes.Call, method, null);
        if (method.ReturnType.IsValueType)
            gen.Emit(System.Reflection.Emit.OpCodes.Box, method.ReturnType);
        gen.Emit(System.Reflection.Emit.OpCodes.Ret);
        return (Func<object, object>)dm.CreateDelegate(typeof(Func<object, object>));
    }
    private static Func<object, object> BuildAccessor(FieldInfo field)
    {
        DynamicMethod dm = new DynamicMethod(field.DeclaringType.Name + field.Name + "FieldAccessor", typeof(object), new Type[] { typeof(object) }, field.DeclaringType);
        var gen = dm.GetILGenerator();
        if (field.IsStatic)
        {
            gen.Emit(System.Reflection.Emit.OpCodes.Ldsfld, field);
        }
        else
        {
            gen.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            gen.Emit(System.Reflection.Emit.OpCodes.Castclass, field.DeclaringType);
            gen.Emit(System.Reflection.Emit.OpCodes.Ldfld, field);
        }
        if (field.FieldType.IsValueType)
            gen.Emit(System.Reflection.Emit.OpCodes.Box, field.FieldType);
        gen.Emit(System.Reflection.Emit.OpCodes.Ret);
        return (Func<object, object>)dm.CreateDelegate(typeof(Func<object, object>));
    }
