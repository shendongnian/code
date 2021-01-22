    using System;
    using System.Runtime.InteropServices;
    namespace Guess
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string str = "ABC";
                Console.WriteLine(str);
                Console.WriteLine(str.GetHashCode());
                var handle = GCHandle.Alloc(str, GCHandleType.Pinned);
                try
                {
                    Marshal.WriteInt16(handle.AddrOfPinnedObject(), 4, 'Z');
                    Console.WriteLine(str);
                    Console.WriteLine(str.GetHashCode());
                }
                finally
                {
                    handle.Free();
                }
            }
        }
    }
