            int i, j, k;
            int value=0;            
            Console.WriteLine("Enter the fist number ");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number ");
            j = Convert.ToInt32(Console.ReadLine());
            if (i > j)
            {
                Console.WriteLine("Second number should be greater then First");
                Console.ReadLine();
                Environment.Exit(0);
            }
            for (k = i; k <= j; k++)
            {
              
                value += k * k;
               
            }
            Console.WriteLine(value);
            Console.ReadLine();
