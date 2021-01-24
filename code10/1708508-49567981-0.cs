    class Program
    {
        static void Main(string[] args)
        {
            Foo temp = new Foo(99);
            Console.WriteLine($"{Marshal.ReadInt32(temp.I)}");
            Console.ReadLine();
        }
    }
    struct Foo
    {
        int i;
        public IntPtr I;
        public Foo(int newInt)
        {
            i = newInt;
            I = GetByRef(i);
        }
        static unsafe private IntPtr GetByRef(int myI)
        {
            TypedReference tr = __makeref(myI);
            int* temp = &myI;
            IntPtr ptr = (IntPtr)temp;
            return ptr;
        }
    }
