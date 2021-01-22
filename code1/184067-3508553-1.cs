        unsafe static void CallSomething(MyClass obj, string arg) {
            IntPtr mem = Marshal.StringToCoTaskMemUni(arg);
            try {
                obj.Something((Char*)mem);
            }
            finally {
                Marshal.FreeCoTaskMem(mem);
            }
        }
