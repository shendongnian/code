    class Program
    {
        static void Main()
        {
            Foo foo = new Foo();
            foo.Name = "Blah";
            Foo<int> newfoo = (Foo<int>)foo;
            Console.WriteLine(newfoo.Name);
            Console.Read();
        }
    }
    
    class Foo
    {
        public string Name { get; set; }
        public object Data { get; set; }
    }
    
    class Foo<T>
    {
        public string Name { get; set; }
        public T Data { get; set; }
        public static explicit operator Foo<T>(Foo foo)
        {
            Foo<T> newfoo = new Foo<T>();
            newfoo.Name = foo.Name;
            return newfoo;
        }
    }
