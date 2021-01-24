    class Program
    {
        static void Main(string[] args)
        {
            MyStruct mc = new MyStruct(10);
    
            // Will print 10
            Console.WriteLine(mc.i);
            unsafe
            {
                MyStruct* pmc = &mc;
                // Will print the address of mc
                Console.WriteLine((IntPtr)pmc);
            }
    
            // Assign to mc
            mc = new MyStruct(20);
    
            // Will print 20; mc was modified
            Console.WriteLine(mc.i);
            unsafe
            {
                MyStruct* p = &mc;
                // Will print the same address as above.
                // mc was modified in place
                // because structs have value semantics
                Console.WriteLine((IntPtr)p);
            }
        }
    }
    
    struct MyStruct
    {
        public MyStruct(int i)
        {
            this.i = i;
        }
        public int i;
    }
