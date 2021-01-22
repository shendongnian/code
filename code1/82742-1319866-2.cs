        private static class ccf
        {
    #if win32
            [DllImport(myDllName32)]
            public static extern int func1();
    #else    
            [DllImport(myDllName64)]
            public static extern int func1();
    #endif
        }
