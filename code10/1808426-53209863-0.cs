    public unsafe class ArrayOfGenericStructs<TStruct> : IDisposable where TStruct:struct
    {
        private void* pointer;
    
        public ArrayOfGenericStructs(int size)
        {
            pointer = (void*) Marshal.AllocHGlobal(Unsafe.SizeOf<TStruct>() * size);
        }
    
        public bool IsDisposed { get; private set; }
    
        public void Dispose()
        {
            if (IsDisposed) return;
            IsDisposed = true;
            if (pointer != null) Marshal.FreeHGlobal(new IntPtr(pointer));
            pointer = null;
        }
    
        public ref TStruct this[int index]
        {
            get
            {
                return ref Unsafe.AsRef<TStruct>(Unsafe.Add<TStruct>(pointer, index));
            }
        }
    }
