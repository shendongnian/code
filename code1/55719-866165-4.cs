    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo(); 
            foreach (int number in foo)
            {
                Console.WriteLine(number);
            }
            // Linq composition - a good trick
            foreach (var pair in foo.EachPair())
            {
                Console.WriteLine("got pair {0} {1}", pair.First, pair.Second);
            }
            // This is a bad and dangerous practice. 
            // All default enumerators should be the same, otherwise
            // people will get confused.
            foreach (string str in (IBar)foo)
            {
                Console.WriteLine(str);
            }
            // Another possible way, I prefer linq composition
            foreach (string str in foo.AnotherIterator())
            {
                Console.WriteLine(str);
            }
        }
