    class Program
    {
        static void Main(string[] args)
        {
            MyStruct mc = new MyStruct(10);
            MyStruct mc2 = new MyStruct(20);
            // Will print 10
            Console.WriteLine(mc.i);
            // Will print False; mc and mc2 are different objects
            Console.WriteLine(Object.ReferenceEquals(mc, mc2));
            mc = mc2;
            // Will print 20; mc was modified
            Console.WriteLine(mc.i);
            // Will still print False
            // mc and mc2 are still different objects
            // because structs have value semantics
            Console.WriteLine(Object.ReferenceEquals(mc, mc2));
        }
    }
    
    struct MyStruct {
        public MyStruct(int i) {
            this.i = i;
        }
        public int i;
    }
