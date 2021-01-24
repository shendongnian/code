    static class Program
    {
        private static void Fizz(int i)
        {
            if (i % 3 == 0) {
                Console.WriteLine("fizz");
            } else {
                Console.WriteLine(i);
            }
        }
 
        private static void Main()
        {
            Fizz(4);
        }
    }
