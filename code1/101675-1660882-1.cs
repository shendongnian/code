    using System.Runtime.InteropServices;
    namespace MyNamespace {
        public static class Device01
	    {
            public const string DLL_NAME = @"Device01.dll";
            [DllImport(DLL_NAME, EntryPoint = "_function1")]
            public static extern int function1(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function2")]
            public static extern int function2(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function3")]
            public static extern int function3(byte[] param);
    		        
        }
        public static class Device02
	    {
            public const string DLL_NAME = @"Device02.dll";
            [DllImport(DLL_NAME, EntryPoint = "_function1")]
            public static extern int function1(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function2")]
            public static extern int function2(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function3")]
            public static extern int function3(byte[] param);
    		        
        }
        public static class Device03
	    {
            public const string DLL_NAME = @"Device03.dll";
            [DllImport(DLL_NAME, EntryPoint = "_function1")]
            public static extern int function1(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function2")]
            public static extern int function2(byte[] param);
            [DllImport(DLL_NAME, EntryPoint = "_function3")]
            public static extern int function3(byte[] param);
    		        
        }
    }
