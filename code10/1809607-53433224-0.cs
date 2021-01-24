	static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArray = input.Split(' ');
            long element;
            long odd = 1;
            long even = 1;
            foreach (var i in inputArray)
            {
                element = long.Parse(i);
                if (element % 2 == 0)
                {
                    even *= element;
                }
                else
                {
                    odd *= element;
                }
            }
            Console.WriteLine("\nOdd product = " + odd + ", Even product = " + even);
            if (odd == even)
            {
                Console.WriteLine("ODD == EVEN \n");
                Console.WriteLine("Yes" + " " + odd);
            }
            else
            {
                Console.WriteLine("ODD != EVEN \n");
                Console.WriteLine("No" + " " + odd + " " + even);
            }
            Console.ReadKey();
        }
