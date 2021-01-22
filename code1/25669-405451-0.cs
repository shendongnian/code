    //Generic class
    class Stuff<T>
    {
        public T value { get; set; }
    }
    class Program
    {
        //First overloaded method
        static void DummyFunc(Stuff<int> value)
        {
            Console.WriteLine("Integer");
        }
        //Second overloaded method
        static void DummyFunc(Stuff<string> value)
        {
            Console.WriteLine("String");
        }
        //Code to call overloaded methods with generic arguments...
        static void Main(string[] args)
        {
            var a = new Stuff<string>();
            a.value = "HelloWorld";
            var b = new Stuff<int>();
            b.value = 1;
            DummyFunc(a);
            DummyFunc(b);
        }
    }
