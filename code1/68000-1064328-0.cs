    using System;
    
    class Foo
    {
    }
    class Bar
    {
        public static explicit operator Bar(Foo f)
        {
            return new Bar();
        }
    }
    
    class Test
    {
        static void Main()
        {
            Foo f = new Foo();
            Bar b = (Bar) f;
            Console.WriteLine(object.ReferenceEquals(f, b)); // Prints False
        }
    }
