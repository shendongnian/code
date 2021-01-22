    class Program
    {
        static void Main(string[] args)
        {
            ConstrainedNumber<int> one = new ConstrainedNumber<int>(10);
            ConstrainedNumber<int> two = new ConstrainedNumber<int>(5);
            var three = one + two;
            Debug.Assert(three == 15);
            Console.ReadLine();
        }
    }
