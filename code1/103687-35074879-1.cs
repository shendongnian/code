    class Program
    {
        static IEnumerable<int> Func1()
        {
            for (int i = 0; i < 3; i++)
                yield return i;
        }
    
        static void Main(string[] args)
        {
            var x1 = Func1();
            foreach (int k in x1) 
                Console.WriteLine(k);
    
            foreach (int k in x1)
                Console.WriteLine(k);
        }
    }
