    using NUnit.Framework;
    using static Fizz.Buzz;
    class Program
    {
        [Test]
        public void Main()
        {
            Method();
            int z = Z;
            object y = Y;
            Y = new object();
        }
    }
    
    
    namespace Fizz
    {
        class Buzz
        {
            public static void Method()
            {
            }
    
            public static int Z;
    
            public static object Y { get; set; }
        }
    }   
