    static void F<T>(ref T t) where T : struct
    {
    }
    static void G<T>(in T t) where T : struct
    {
        F(ref System.Runtime.CompilerServices.Unsafe.AsRef(in t));
    }
