    using System.Runtime.CompilerServices;
    ...
    void Main()
    {
    	RuntimeHelpers.RunClassConstructor(typeof(Foo).TypeHandle);
        RuntimeHelpers.RunClassConstructor(typeof(Foo).TypeHandle);
        Foo.Bar();
    }
    
    class Foo
    {
        static Foo()
        {
            Console.WriteLine("Foo");
        }
        
        public static void Bar()
        {
            Console.WriteLine("Bar");
        }
    }
