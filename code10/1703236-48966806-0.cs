    using System;
    using System.Runtime.InteropServices;
    // Namespace is optional but generally recommended.
    namespace MyDLLImports
    {
        static class MyDLLWrapper
        {
            // Use DllImport to import the SayHi() function.
            [DllImport("mydll.dll", CharSet = CharSet.Unicode)]
            public static extern void SayHi();
        }
    }
    class Program
    {
        static void SayHi()
        {
            // whatever...
        }
        static void Main()
        {
            // Call the different SayHi() functions.
            MyImports.MyDLLWrapper.SayHi();
            SayHi();
        }
    }
