    #if x86
            public const string DLL_FILE_NAME = "DLL_32.dll";
    #else
            public const string DLL_FILE_NAME = "DLL_64.dll";
    #endif
    
            [DllImport(DLL_FILE_NAME, EntryPoint = "Foo", CallingConvention = CallingConvention.Cdecl)]
            private static extern int Foo1(int var1, int var2);
