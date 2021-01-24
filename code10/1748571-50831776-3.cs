    public static void Main(string[] args)
    {
        object a = null;
        object b = null;
        Console.WriteLine(AreSame(ref a, ref b));  // prints False
        Console.WriteLine(AreSame(ref a, ref a));  // prints True
    }
    static bool AreSame<T1, T2>(ref T1 a, ref T2 b)
    {
        TypedReference trA = __makeref(a);
        TypedReference trB = __makeref(b);
        unsafe
        {
            return *(IntPtr*)(&trA) == *(IntPtr*)(&trB);
        }
    }
