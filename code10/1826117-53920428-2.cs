    struct Foo
    {
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 5)]
        public int[] Data;      
    }
 
    class Program
    {
        [DllImport("MyPtr.dll",EntryPoint = "InitializeDLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitializeDLL([MarshalAs(UnmanagedType.FunctionPtr)] ResultCallback callbackPointer);
        
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void ResultCallback(Foo value);
        static void CallBackMe(Foo value)
        {
            //value.Data is equal to [0,1,2,3,4]
        }
        static void Main(string[] args)
        {
            var result = InitializeDLL(CallBackMe);
        }
    }
