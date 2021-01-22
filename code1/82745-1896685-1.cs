    private static class ccf
    {
        [DllImport("myDllName")]
        public static extern int func1();
    }
    
    public static class ExampleDllLoader
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private extern static IntPtr LoadLibrary(string librayName);
    
        public static void LoadDll()
        {
            String path;
    
            //IntPtr.Size will be 4 in 32-bit processes, 8 in 64-bit processes 
            if (IntPtr.Size == 4)
                path = "c:/example32bitpath/myDllName.dll";
            else
                path = "c:/example64bitpath/myDllName.dll";
    
            LoadLibrary(path);
        }
    }
