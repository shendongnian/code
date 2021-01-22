    class Program
    {
        public static int Combine(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            var combineMethod = typeof(Program).GetMethod("Combine");
            var add4 = Delegate.CreateDelegate(
                                  typeof(Converter<int, int>),
                                  4,
                                  combineMethod) as Converter<int, int>;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(add4(i));
            }
            Console.ReadLine();
        }
    }
