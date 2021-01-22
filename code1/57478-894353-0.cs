    namespace AnonType
    {
        class Program
        {
            static void Main(string[] args)
            {
                var foo = new { a = "123", b = "abc" };
    
                Anon(foo);
                Console.ReadLine();
            }
    
            public static void Anon(object o)
            {
                Console.WriteLine(o);
            }
        }
    }
