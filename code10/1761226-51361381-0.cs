    class Program
    {
        public static T Adds<T>(object number1, object number2)
        {
            if ((number1 is int) && (number2 is int))
            {
                Console.WriteLine("int test");
            }
            else if (number1 is double)
            {
                Console.WriteLine("double test");
            }
            return (T)Convert.ChangeType(number1, typeof(T));
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(Adds<int>('c', 2));
        }
    }
