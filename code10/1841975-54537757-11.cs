    using System;
    using System.Runtime.CompilerServices;
    
    
    struct Foo
    {
        public int x, y;
    }
    class MyClass<T>
    {
        public T Value = default(T);
    
        public unsafe MyClass(byte[] bytes)
        {
            if (bytes.Length < Unsafe.SizeOf<T>())
                throw new InvalidOperationException("not enough data");
            Value = Unsafe.As<byte, T>(ref bytes[0]);
        }
    }
    static class P
    {
        static void Main() {
            byte[] bytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var obj = new MyClass<Foo>(bytes);
            var val = obj.Value;
            Console.WriteLine(val.x); // 67305985 = 0x04030201
            Console.WriteLine(val.y); // 134678021 = 0x08070605 
        }
    }
