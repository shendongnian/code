        static void Main(string[] args)
        {
            var str = right("Hello", 3);
            Console.WriteLine(str.GetType()); // System.String
            var ch = right("Hello", 4);
            Console.WriteLine(ch.GetType()); // System.Char
        }
