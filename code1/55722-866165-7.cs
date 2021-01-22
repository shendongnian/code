    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo(); 
            foreach (int number in foo)
            {
                Console.WriteLine(number);
            }
            // LINQ composition - a good trick where you want
            //  another way to iterate through the same data 
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
            // Another possible way, which can be used to iterate through
            //   a portion of your collection eg. Dictionary.Keys 
            foreach (string str in foo.AnotherIterator)
            {
                Console.WriteLine(str);
            }
        }
