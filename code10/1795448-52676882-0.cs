    using System.Runtime.InteropServices;
    namespace Microsoft.Z3
    {
        public static class DoSomething
        {
            [DllImport("libz3.dll")]
            public static extern int ReturnValue(int value);
        }
    }
