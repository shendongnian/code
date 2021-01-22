    public delegate void SetterDelegate(ref object target, object value);
    private static Type ByRefObject = typeof(object).MakeByRefType();
    private static SetterDelegate CreateSetMethod(MemberInfo memberInfo)
    {
        Type ParamType;
        if (memberInfo is PropertyInfo)
            ParamType = ((PropertyInfo)memberInfo).PropertyType;
        else if (memberInfo is FieldInfo)
            ParamType = ((FieldInfo)memberInfo).FieldType;
        else
            throw new Exception("Can only create set methods for properties and fields.");
        DynamicMethod setter = new DynamicMethod(
            "",
            typeof(void),
            new Type[] {
                ByRefObject,
                typeof(object) },
            memberInfo.ReflectedType.Module,
            true);
        ILGenerator generator = setter.GetILGenerator();
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldind_Ref);
        if (memberInfo.DeclaringType.IsValueType)
        {
    #if UNSAFE_IL
            generator.Emit(OpCodes.Unbox, memberInfo.DeclaringType);
    #else
            generator.DeclareLocal(memberInfo.DeclaringType.MakeByRefType());
            generator.Emit(OpCodes.Unbox, memberInfo.DeclaringType);
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
    #endif // UNSAFE_IL
        }
        generator.Emit(OpCodes.Ldarg_1);
        if (ParamType.IsValueType)
            generator.Emit(OpCodes.Unbox_Any, memberInfo.DeclaringType);
        if (memberInfo is PropertyInfo)
            generator.Emit(OpCodes.Callvirt, ((PropertyInfo)memberInfo).GetSetMethod());
        else if (memberInfo is FieldInfo)
            generator.Emit(OpCodes.Stfld, (FieldInfo)memberInfo);
        if (memberInfo.DeclaringType.IsValueType)
        {
    #if !UNSAFE_IL
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Ldobj, memberInfo.DeclaringType);
            generator.Emit(OpCodes.Box, memberInfo.DeclaringType);
            generator.Emit(OpCodes.Stind_Ref);
    #endif // UNSAFE_IL
        }
        generator.Emit(OpCodes.Ret);
        return (SetterDelegate)setter.CreateDelegate(typeof(SetterDelegate));
    }
