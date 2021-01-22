    class Program
    {
        
        static List<int> right = new List<int> { 0, 2, 4 };
        static void Main(string[] args)
        {
            var left = new List<int> { 1, 2, 3 };
            left.Aggregate(0, (accum, value) => FuncWithSideEffects(accum, value));
        }
        static int FuncWithSideEffects(int acc, int left)
        {
            if (left == right[acc])
                Console.WriteLine("yay equality - MAGIC");
            Console.WriteLine("doing SomethingElse with: " + left);
            return ++acc;
        }
    }
