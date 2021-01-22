    public class SampleClass : IDisposable
    {    
        [DllImport("YourDll.dll", EntryPoint="ConstructorOfYourClass", CharSet=CharSet.Ansi,          CallingConvention=CallingConvention.ThisCall)]
        public extern static void SampleClassConstructor(IntPtr thisObject);
        [DllImport("YourDll.dll", EntryPoint="DestructorOfYourClass", CharSet=CharSet.Ansi,          CallingConvention=CallingConvention.ThisCall)]
        public extern static void SampleClassDestructor(IntPtr thisObject);
        [DllImport("YourDll.dll", EntryPoint="DoSomething", CharSet=CharSet.Ansi,      CallingConvention=CallingConvention.ThisCall)]
        public extern static void DoSomething(IntPtr thisObject);
        [DllImport("YourDll.dll", EntryPoint="DoSomethingElse", CharSet=CharSet.Ansi,      CallingConvention=CallingConvention.ThisCall)]
        public extern static void DoSomething(IntPtr thisObject, int x);
        IntPtr ptr;
        public SampleClass(int sizeOfYourCppClass)
        {
            this.ptr = Marshal.AllocHGlobal(sizeOfYourCppClass);
            SampleClassConstructor(this.ptr);  
        }
    
        public void DoSomething()
        {
            DoSomething(this.ptr);
        }
        public void DoSomethingElse(int x)
        {
            DoSomethingElse(this.ptr, x);
        }
        
        public void Dispose()
        {
            if (this.ptr != IntPtr.Zero)
            {
                // The following 2 calls equals to "delete object" in C++
                // Calling the destructor of the C++ class will free the memory allocated by the native c++ class.
                SampleClassDestructor(this.ptr);
                // Free the memory allocated from .NET.
                Marshal.FreeHGlobal(this.ptr);
                this.ptr = IntPtr.Zero;
            }
        }
    }
