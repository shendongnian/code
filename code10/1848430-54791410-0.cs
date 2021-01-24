            int a;
            int b;
            int x;
            int y;
            Console.WriteLine("A");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("B");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("X");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Y");
            y = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < y; i++)
            {
                Console.Write("\n");
            }
            for (int j = 0; j < x; j++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < a; i++)
                Console.Write("*");
            Console.Write("\n");
            
            for (int i = 0; i < b - 2; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("*");
                for (int k = 0; k < a - 2; k++)
                    Console.Write(" ");
                Console.Write("*");
                Console.Write("\n");
            }
            for (int j = 0; j < x; j++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < a; i++)
                Console.Write("*");
            Console.Write("\n");
            Console.ReadLine();
