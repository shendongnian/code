    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[]{5,10,12,1};
            var orderd = numbers.OrderBy(num => num = num != 10 ? num : -1);
            foreach (var num in orderd)
            {
                Console.WriteLine("number is {0}", num);
            }
            Console.ReadLine();
        }
    }
