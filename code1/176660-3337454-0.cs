    /// <summary>
    /// IntPtr wrapper which can be used as result of
    /// Marshal.AllocHGlobal operation.
    /// Call Marshal.FreeHGlobal when disposed or finalized.
    /// </summary>
    class HGlobalSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Creates new instance with given IntPtr value
        /// </summary>
        public HGlobalSafeHandle(IntPtr ptr) : base(ptr, true)
        {
        }
        /// <summary>
        /// Creates new instance with zero IntPtr
        /// </summary>
        public HGlobalSafeHandle() : base(IntPtr.Zero, true)
        {
        }
        /// <summary>
        /// Creates new instance which allocates unmanaged memory of given size 
      /// Can throw OutOfMemoryException
        /// </summary>
        public HGlobalSafeHandle(int size) :
            base(Marshal.AllocHGlobal(size), true)
        {
        }
        /// <summary>
        /// Allows to assign IntPtr to HGlobalSafeHandle
        /// </summary>
        public static implicit operator HGlobalSafeHandle(IntPtr ptr)
        {
            return new HGlobalSafeHandle(ptr);
        }
        /// <summary>
        /// Allows to use HGlobalSafeHandle as IntPtr
        /// </summary>
        public static implicit operator IntPtr(HGlobalSafeHandle h)
        {
            return h.handle;
        }
        /// <summary>
        /// Called when object is disposed or finalized.
        /// </summary>
        override protected bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);
            return true;
        }
        /// <summary>
        /// Defines invalid (null) handle value.
        /// </summary>
        public override bool IsInvalid
        {
            get
            {
                return (handle == IntPtr.Zero);
            }
        }
    }
