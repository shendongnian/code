    class MyClass<T> where T : unmanaged
    {
        public T Value = default(T);
    
        public unsafe MyClass(byte[] bytes)
        {
            fixed (byte* ptr = bytes)
            {
                Value = *(T*)ptr; // note: no out-of-range check here; dangerous
            }
        }
    }
