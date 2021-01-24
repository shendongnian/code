    // Allocator of T[] that pins the memory (and handles unpinning)
    public sealed class PinnedArray<T> : IDisposable where T : struct
    {
        private GCHandle handle;
        public T[] Array { get; private set; }
        public IntPtr CreateArray(int length)
        {
            FreeHandle();
            Array = new T[length];
            // try... finally trick to be sure that the code isn't interrupted by asynchronous exceptions
            try
            {
            }
            finally
            {
                handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            }
            return handle.AddrOfPinnedObject();
        }
        // Some overloads to handle various possible length types
        // Note that normally size_t is IntPtr
        public IntPtr CreateArray(IntPtr length)
        {
            return CreateArray((int)length);
        }
        public IntPtr CreateArray(long length)
        {
            return CreateArray((int)length);
        }
        public void Dispose()
        {
            FreeHandle();
        }
        ~PinnedArray()
        {
            FreeHandle();
        }
        private void FreeHandle()
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr AllocateResultOfStrategyArray(IntPtr length);
    [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void MyCppFunc2(
        AllocateResultOfStrategyArray allocator
    );
