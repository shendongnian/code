    class Program
    {
        static int Add(int a, int b) => a + b;
        static int Doubling(int a) => Add(a, a);
        static int Quadrupling(int a) => Add(Add(a, a), Add(a, a));
        static void Main(string[] args)
        {
            Console.WriteLine("Inner method calls");
            Console.WriteLine("        Add: {0}", ((Func<int, int, int>)Add).Method.NbOfInnerCalls());
            Console.WriteLine("   Doubling: {0}", ((Func<int, int>)Doubling).Method.NbOfInnerCalls());
            Console.WriteLine("Quadrupling: {0}", ((Func<int, int>)Quadrupling).Method.NbOfInnerCalls());
        }
    }
    // Output:
    // Inner method calls
    //         Add: 0
    //    Doubling: 1
    // Quadrupling: 3
   
