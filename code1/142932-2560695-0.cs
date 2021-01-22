    class Foo {}
    
    class Bar
    {
        public static implicit operator Foo(Bar bar)
        {
            throw new NullReferenceException();
        }
    }
    
    class Program
    {
        public static void Main()
        {
           Foo foo = new Bar(); // This causes a NullReferenceException to be thrown.
        }
    }
