    class MyClass<T>
    {
        public T Value = default(T);
    
        public unsafe MyClass(byte[] bytes)
        {
            T local = default(T);
            fixed (byte* ptr = bytes)
            {
                Unsafe.Copy(ref local, ptr); // note: no out-of-range check here; dangerous
            }
            Value = local;
        }
    }
