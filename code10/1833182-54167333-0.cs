    do
        {
            Console.WriteLine("\nHow many bricks to take (1, 2 or 3)?");
            int user = int.Parse(Console.ReadLine());
            n = n - user;
            if (n < 1)
            {
                Console.WriteLine("\nComputer lost!");
            }
            else
            {
                Random rn = new Random();
                int comp;
                if(n <= 3)
                {
                    comp = n; //For computer to take the remaining bricks
                }
                else
                {
                    int comp = rn.Next(1, 4);
                }
                n = n - comp;
                Console.WriteLine("\nComputer took:" + comp);
                if (n < 1)
                {
                    Console.WriteLine("\nYou lost!");
                }
            }
        } while(n > 0);
