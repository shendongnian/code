    class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int RequestDelegate(
            IntPtr hLoginInstance, 
            IntPtr hDialog, 
            IntPtr data, 
            int pdwAppParam);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int ResponseDelegate(
            IntPtr hLoginInstance, 
            IntPtr hDialog, 
            string szString, 
            int dwAppParam);
    
        [DllImport("somelib.dll")]
        public static extern void RegisterCallbackFunctions(TCallbacks callbacks);
        public struct TCallbacks
        {
            public RequestDelegate m_pOnRequest;
            public ResponseDelegate m_pOnResponse;
        }
        static void Main(string[] args)
        {
            TCallbacks callbacks;
            callbacks.m_pOnRequest = 
                (hLoginInstance, hDialog, data, pdwAppParam) => 10;
            callbacks.m_pOnResponse = 
                (hLoginInstance, hDialog, szString, dwAppParam) => 20;
            RegisterCallbackFunctions(callbacks);
        }
    } 
