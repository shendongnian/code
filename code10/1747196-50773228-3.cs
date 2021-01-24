    class Example   // this class is defined in a different assembly and is not known at compile time
    {
        public double foo;
    }
    static void Main(string[] args)
    {
        Example obj = new Example();
        obj.foo = 123;
        var hdl = GCHandle.Alloc(obj);
        unsafe
        {
            IntPtr foo_add = GetAddressOf(obj, "foo");
            double* ptr = (double*) foo_add;
            Console.WriteLine("Current Value: {0}", *ptr);
            *ptr = 4;
            Console.WriteLine("Updated Value: {0}", obj.foo);
        }
        hdl.Free();
        Console.ReadLine();
    }
