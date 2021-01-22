    using System;
    using System.Runtime.InteropServices;
    static class Program{
        delegate void FooCallback(int i);
        [DllImport(@"C:\Path\To\Unmanaged\C.dll")]
        static extern void Foo(int start, int end, FooCallback callback);
        static void Main(){
            FooCallback callback = i=>Console.WriteLine(i);
            Foo(0, 10, callback);
            GC.KeepAlive(callback); // to keep the GC from collecting the delegate
        }
    }
