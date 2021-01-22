    public static void ZeroInit<T>(ref T value)
        where T : struct
    {
        Ldarg(nameof(value));
        Ldc_I4_0();
        Sizeof(typeof(T));
        Unaligned(1);
        Initblk();
    }
