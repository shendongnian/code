    private static bool IsBetween(int value, int min, int max)
    {
        return (value >= min && value <= max);
    }
    
    private static void WriteInt(ILGenerator gen, int value)
    {
        gen.Emit(OpCodes.Ldarg_1);
        if (IsBetween(value, sbyte.MinValue, sbyte.MaxValue))
        {
            gen.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
        }
        else if (IsBetween(value, byte.MinValue, byte.MaxValue))
        {
            gen.Emit(OpCodes.Ldc_I4_S, (byte)value);
        }
        else if (IsBetween(value, short.MinValue, short.MaxValue))
        {
            gen.Emit(OpCodes.Ldc_I4_S, (short)value);
        }
        else
        {
            gen.Emit(OpCodes.Ldc_I4_S, value);
        }
    }
