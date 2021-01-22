        using System.Runtime.InteropServices;
        namespace ImportDLL
        {
        public class importdll
        {
        public importdll()
        {
        }
        DllImport("mysum.dll",
                  EntryPoint="sum",
                  ExactSpelling=false,
                  CallingConvention = CallingConvention.Cdecl)]
        public extern int myfun(int a, int b);
        }
        }
