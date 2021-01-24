    [DllImport("CPlusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Allocate(IntPtr bytes);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr TestPassingString();
    [DllImport("CPlusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetCallbackTestPassingString(TestPassingString callback);
    [DllImport("CPlusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Test();
    // Simple method to copy a string to a IntPtr, including the terminating \0
    public static void CopyStringUnicodeToPtr(string str, IntPtr ptr)
    {
        for (int j = 0; j < str.Length; j++)
        {
            Marshal.WriteInt16(ptr, j * sizeof(char), str[j]);
        }
        // \0 terminator
        Marshal.WriteInt16(ptr, str.Length * sizeof(char), 0);
    }
    public IntPtr MyTestPassingString()
    {
        string[] strings = new[]
        {
            "Foo",
            "Bar",
            "FooBar",
            "Baz",
            "FooBarBaz",
        };
        IntPtr ptr = Allocate((IntPtr)(strings.Length * IntPtr.Size));
        for (int i = 0; i < strings.Length; i++)
        {
            string str = strings[i];
            // The +1 is for the terminating \0
            IntPtr ptr2 = Allocate((IntPtr)((str.Length + 1) * sizeof(char)));
            Marshal.WriteIntPtr(ptr, i * IntPtr.Size, ptr2);
            CopyStringUnicodeToPtr(str, ptr2);
        }
        return ptr;
    }
