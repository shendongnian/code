    public void EmitFieldGetter(ILGenerator gen, FieldInfo field)
    {
        gen.Emit(OpCodes.Ldarg_0);
        gen.Emit(OpCodes.Ldfld, field);
        if (field.FieldType.IsValueType)
        {
            gen.Emit(OpCodes.Box, field.FieldType);
        }
        gen.Emit(OpCodes.Ret);
    }
