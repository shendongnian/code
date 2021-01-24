    internal class Program
    {
        public Program()
        {
        }
        private static int CalculateSomethingExpensive()
        {
            return (new Random()).Next(100);
        }
        [Conditional("DEBUG")]
        private static void CheckResult(bool resultIsOK)
        {
            Console.WriteLine((resultIsOK ? "OK" : "not OK"));
        }
        public static void Main(string[] args)
        {
        }
    }
