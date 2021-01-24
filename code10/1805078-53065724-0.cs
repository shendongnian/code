    namespace Eff3
    {
        using System.Collections.Generic;
        using System.Runtime.InteropServices;
        delegate void DictionaryAdd(string key, int value);
        class Program
        {
            [DllImport("TestDll")]
            static extern void doFoo(DictionaryAdd callback);
            static void Main()
            {
                var result = new Dictionary<string, int>();
                doFoo(result.Add);
            }
        }
    }
