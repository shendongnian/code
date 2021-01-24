    public class MemWrapper<T> where T : struct
    {
        readonly IntPtr pointerToUnmanagedHeapMem;
    
        // ... do some memory management also ...
    
        public unsafe ref T Ptr
        {
            get { return ref Unsafe.AsRef<T>(pointerToUnmanagedHeapMem.ToPointer()); }
        }
    }
