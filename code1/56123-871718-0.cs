    class Program
    {
        static string[] ar = new[] { "a", "b", "c", "d", "a", "a", "f", "g",  
            "d", "i", "j", "a","d", "c", "g" };
        static void Main(string[] args)
        {
            var dist = (from a in ar select a).Distinct();// distinct;
            foreach (var v in dist)
                Console.Write(v);
            Console.ReadLine();
        }
    }
