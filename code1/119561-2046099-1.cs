    public delegate int AddSomething(int x);
    public class Foo
    {
        public static void Main(string[] args)
        {
            // the following are equivalent
            AddSomething add1 = Foo.PlusAnything;
            AddSomething add1alt = new AddSomething(Foo.PlusAnything);
            Console.WriteLine(add1(5)); // prints "6"
            
            // instance delegates, bound to a method on a particular instance
            AddSomething add3 = new Foo(3).AddAnything;
            AddSomething add5 = new Foo(5).AddAnything;
            Console.WriteLine(add3(4)); // prints "7"
            Console.WriteLine(add5(6)); // prints "11"            
        }
       
        static int PlusOne(int x)  { return x+1; }
        private int y;
        public Foo(int toAdd) { this.y = toAdd; }
        int PlusAnything(int x)  { return x+this.y; } 
    }
