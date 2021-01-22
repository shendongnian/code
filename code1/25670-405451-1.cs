    class Stuff<T>
    {
        public T value { get; set; }
    }
    class Program
    {
        static void DummyFunc(Stuff<int> inst)
        {
            Console.WriteLine("Stuff<int>: {0}", inst.value.ToString());
        }
        static void DummyFunc(Stuff<string> inst)
        {
            Console.WriteLine("Stuff<string>: {0}", inst.value);
        }
        static void DummyFunc(int value)
        {
            Console.WriteLine("int: {0}", value.ToString());
        }
        static void DummyFunc(string value)
        {
            Console.WriteLine("string: {0}", value);
        }
        static void Main(string[] args)
        {
            var a = new Stuff<string>();
            a.value = "HelloWorld";
            var b = new Stuff<int>();
            b.value = 1;
            var c = "HelloWorld";
            var d = 1;
            DummyFunc(a);
            DummyFunc(b);
            DummyFunc(c);
            DummyFunc(d);
        }
    }
