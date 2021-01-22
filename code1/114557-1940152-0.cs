    class Program
    {
        private static void Main(string[] args)
        {
            string result = null;
            DoSomething(number => result = number.ToString());
            Console.WriteLine(result);
        }
    
        private static void DoSomething(Action<int> func)
        {
            func(10);
        }
    }
