    class PlatformInvokeTest
    {
        [DllImport("msvcrt.dll")]  // Specify the DLL we're importing from
        public static extern int puts(string c); // This matches the signature of the DLL function.  The CLR automatically marshals C++ types to C# types.
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
        public static void Main() 
        {
            puts("Test");
            _flushall();
        }
    }
