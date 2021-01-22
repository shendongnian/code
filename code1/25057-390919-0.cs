    namespace TestProject
    {
    class Program
    {
        static void Main(string[] args)
        {
            Test a = new Test();
            Test b = new Test();
            Console.WriteLine("Inline:");
            bool x = a == b;
            Console.WriteLine("Generic:");
            Compare<Test>(a, b);
        }
        static bool Compare<T>(T x, T y) where T : class
        {
            return x == y;
        }
    }
    class Test
    {
        public static bool operator ==(Test a, Test b)
        {
            Console.WriteLine("Overloaded == called");
            return a.Equals(b);
        }
        public static bool operator !=(Test a, Test b)
        {
            Console.WriteLine("Overloaded != called");
            return a.Equals(b);
        }
    }
