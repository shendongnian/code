    internal interface IFoo
    {
        void Method1(int a, float b);
        void Method2(int a, float b, int c);
    }
    internal static class UnsafeNativeMethods
    {
        public static IFoo GetFooInterface()
        {
            IntPtr self = GetInterface(InterfaceType.Foo);
            NativeFoo nativeFoo = (NativeFoo)Marshal.PtrToStructure(self, typeof(NativeFoo));
            return new NativeFooWrapper(self, nativeFoo.Method1, nativeFoo.Method2);
        }
        [DllImport("mydll.dll", EntryPoint = "getInterface", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetInterface(InterfaceType id);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void Method1Delegate(IntPtr self, int a, float b);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void Method2Delegate(IntPtr self, int a, float b, int c);
        private enum InterfaceType
        {
            Foo,
            Bar
        }
        private struct NativeFoo
        {
            public Method1Delegate Method1;
            public Method2Delegate Method2;
        }
        private sealed class NativeFooWrapper : IFoo
        {
            private IntPtr _self;
            private Method1Delegate _method1;
            private Method2Delegate _method2;
            public NativeFooWrapper(IntPtr self, Method1Delegate method1, Method2Delegate method2)
            {
                this._self = self;
                this._method1 = method1;
                this._method2 = method2;
            }
            public void Method1(int a, float b)
            {
                _method1(_self, a, b);
            }
            public void Method2(int a, float b, int c)
            {
                _method2(_self, a, b, c);
            }
        }
    }
