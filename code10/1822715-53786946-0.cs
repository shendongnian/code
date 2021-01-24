            Random rnd = new Random();
            int[,] lala = new int[5, 6];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    lala[i, j] = rnd.Next(1, 10);
                    Console.Write(lala[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
            //int i, j;
            int[] b = new int[30];
            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    b[k++] = lala[i, j];
                }
            }
            for (int i = 0; i < 5 * 6; i++)
            {
                Console.WriteLine(b[i] + " ");
            }
            Console.ReadKey();
