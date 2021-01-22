            int[] x = new int[] { 3, 6, 9, 12 };
            int[] y = new int[] { 3, 6, 9, 12 };
            Console.WriteLine("Hello World");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(x[i]);
            }
            sw.Stop();
            long elapsedTime = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();
            foreach (var item in y)
            {
                Console.WriteLine(item);
            }
            sw.Stop();
            long elapsedTime2 = sw.ElapsedTicks;
            Console.WriteLine("\nSummary");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("for:\t{0}\nforeach:\t{1}", elapsedTime, elapsedTime2);
            Console.ReadKey();
