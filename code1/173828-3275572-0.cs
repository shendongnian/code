    struct Foo
    {
        public int X;
        public override string ToString()
        {
            return "Foo.X == " + X.ToString();
        }
    }
    
    class Program
    {
        static void ModifyFoo(Foo foo)
        {
            foo.X = 5;
            System.Console.WriteLine(foo);
        }
    
        static void Main()
        {
            Foo foo = new Foo();
            foo.X = 123;
            ModifyFoo(foo);
            System.Console.WriteLine(foo);
        }
    }
