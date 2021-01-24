            {
            Console.Write("Hur stor kvadrat vill du ha? ");
            int size = Convert.ToInt32(Console.ReadLine());
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        } code here
