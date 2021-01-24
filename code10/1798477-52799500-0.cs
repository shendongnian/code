    class Program
    {
        public static void Main(string[] args)
        {
            CheckResult(CalculateSomethingExpensive() == 100);
        }
        private static int CalculateSomethingExpensive()
        {
            var result = new Random().Next(100);//some sort of expensive operation here
            return result;
        }
        [Conditional("DEBUG")]
        private static void CheckResult(bool resultIsOK)
        {
            System.Console.WriteLine(resultIsOK ? "OK" : "not OK");
        }
    }
