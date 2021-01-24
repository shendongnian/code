    class MyClass<T> where T : struct
    {
        public T Value = default(T);
    
        public MyClass(byte[] bytes)
        {
            Value = MemoryMarshal.Cast<byte, T>(bytes)[0];
        }
    }
