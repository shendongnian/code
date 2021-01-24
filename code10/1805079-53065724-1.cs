    namespace Eff3
    {
        using System.Collections.Generic;
        using System.Runtime.InteropServices;
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void DictionaryAdd(string key, int value);
        class Program
        {
            [DllImport("TestDll", CallingConvention = CallingConvention.Cdecl)]
            static extern void doFoo(DictionaryAdd callback);
            static void Main()
            {
                var result = new Dictionary<string, int>();
                doFoo(result.Add);
            }
        }
    }
