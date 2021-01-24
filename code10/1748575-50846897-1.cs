    static bool AreSame<T1, T2>(ref T1 a, ref T2 b)
    {
        IL.Emit.Ldarg(nameof(a));
        IL.Emit.Ldarg(nameof(b));
        IL.Emit.Ceq();
        return IL.Return<bool>();
    }
