     static void Main(string[] args)
        {
            int a, b, c, d;
            Console.WriteLine("enter a value:");
            a = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("enter b value:");
            b = Convert.ToInt32(Console.ReadLine());
            for (d = 1; d <=b; d++)
            {
                c = a * d;
              Console.WriteLine("{0}*{1}={2}",a,d,c);
              
            }
            Console.ReadLine();
        }
