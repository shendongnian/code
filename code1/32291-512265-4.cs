        static void Main()
        {
            int[] data = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int i in data)
            {
                new Thread(() => Console.WriteLine(i)).Start();
            }
            Console.ReadLine();
        }
