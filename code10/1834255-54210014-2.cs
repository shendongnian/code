            int[] x = new int[] { 5, 7, -100, 400, 8 };
            int max;
            max = x[0];
            foreach (int elem in x)
            {
                if (elem > max)
                    max = elem;
            }
            
            Console.WriteLine("MAX=" + max);
            Console.ReadLine();
