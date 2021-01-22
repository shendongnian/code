    class Program
    {
        static void Main(string[] args)
        {
            Program p =new Program();
            int x; int y;
            Console.WriteLine("Enter the starting value");
            x  = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Last value");
            y = Convert.ToInt32(Console.ReadLine());
            if (x == 1)
                x++;
            List<int> primeNumber = p.prime(x,y);
            foreach (int num in primeNumber)
            {
                Console.WriteLine(num);
            }
            Console.ReadLine();
        }
        List<int> prime(int x, int y)
        {
            List<int> a = new List<int>();
            int b = 0;
            for (int m = x; m < y; m++)
            {
                for (int i = 2; i <= m / 2; i++)
                {
                    b = 0;
                    if (m % i == 0)
                    {
                        b = 1;
                        break;
                    }
                }
                if (b == 0) a.Add(m)`
            }
          return a;
       
        }
