    class Program
    {
        static void Main(string[] args)
        {
            var testA = new Foo<A>();
            testA.Method();
            var testB = new Foo<B>();
            testB.Method();
            Console.ReadLine();
            var testString = new Foo<string>(); //Fails
            testString.Method(); 
            Console.ReadLine();
        }
    }
    
    class A { }
    class B { }
    class Bar
    {
        public static void OverloadedMethod(Foo<A> a)
        {
            Console.WriteLine("A");
        }
        public static void OverloadedMethod(Foo<B> b)
        {
            Console.WriteLine("B");
        }
    }
    class Foo<T>
    {
        static Foo()
        {
            overloaded = (Action<Foo<T>>)Delegate.CreateDelegate(typeof(Action<Foo<T>>), typeof(Bar).GetMethod("OverloadedMethod", new Type[] { typeof(Foo<T>) }));
        }
    
        public void Method()
        {
            overloaded(this);
        }
    
        private static readonly Action<Foo<T>> overloaded;
    }
