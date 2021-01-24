     class Program
    {
        static int add(params int[] number)
        {
            int sum = 0;
            foreach (int n in number)
            {
                sum = sum + n;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.Write("The sum of the given number is: ");
            Console.Write(string.Format("{0:N1}", Convert.ToDecimal(add(1, 2, 3))));
            //Output : The sum of the given number is: 6.0
            Console.ReadLine();
        }
    }
