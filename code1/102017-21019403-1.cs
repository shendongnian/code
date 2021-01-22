    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 5, 10, 12, 1 };
            var ordered = numbers.OrderBy(num => num != 10 ? num : -1);
            foreach (var num in ordered)
            {
                Console.WriteLine("number is {0}", num);
            }
            Console.ReadLine();
        }
    }
