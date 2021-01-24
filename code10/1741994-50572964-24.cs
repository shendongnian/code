    // Allocator of ResultOfStrategy[] that pins the memory (and handles unpinning)
    public sealed class ResultOfStrategyContainer : IDisposable
    {
        public ResultOfStrategy[] ResultOfStrategy;
        private GCHandle handle;
        public IntPtr CreateArray(IntPtr length)
        {
            FreeHandle();
            ResultOfStrategy = new ResultOfStrategy[(int)length];
            // try... finally trick to be sure that the code isn't interrupted by asynchronous exceptions
            try
            {
            }
            finally
            {
                handle = GCHandle.Alloc(ResultOfStrategy, GCHandleType.Pinned);
            }
            return handle.AddrOfPinnedObject();
        }
        public void Dispose()
        {
            FreeHandle();
        }
        ~ResultOfStrategyContainer()
        {
            FreeHandle();
        }
        private void FreeHandle()
        {
            if (handle.IsAllocated)
            {
                // try... finally trick to be sure that the code isn't interrupted by asynchronous exceptions
                try
                {
                }
                finally
                {
                    handle.Free();
                }
            }
        }
    }
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr AllocateResultOfStrategyArray(IntPtr length);
    [DllImport("CplusPlusSide.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void MyCppFunc2(
        AllocateResultOfStrategyArray allocator
    );
