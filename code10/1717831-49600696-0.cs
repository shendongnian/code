    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string number = Console.In.ReadLine();
            foreach (var num in number.Select(digit => int.Parse(digit.ToString())))
            {
                sum += num;
                if (sum >= 20)
                    break; 
            }
            Console.WriteLine("Sum :{0}",sum);
            Console.ReadLine();
        }
    }
