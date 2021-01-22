    internal static class NativeMethods
    {
        private static string DllName = @"api.dll";
        // This uses 'string' assuming you do not have to free the memory.
        [DllImport(DllName, EntryPoint = "errMessage",
             CharSet = YourCharacterSet,              // CharSet.Ansi? .Unicode?
             CallingConvention = DllCallingConvention // .StdCall? .Cdecl?
        )]
        public static string errMessage(int errorCode);
    }
