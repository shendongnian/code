        [DllImport("MyPtr.dll",EntryPoint = "InitializeDLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitializeDLL([MarshalAs(UnmanagedType.FunctionPtr)]ResultCallback callbackPointer);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void ResultCallback(ref Foo value);
        static void CallBackMe(ref Foo value)
        {
            var buffer = new int[5];
            value.GetData(ref buffer,buffer.Length);
        }
        static void Main(string[] args)
        {
            InitializeDLL(CallBackMe);
        }
    }
