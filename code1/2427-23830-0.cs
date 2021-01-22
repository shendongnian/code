        static void Main(string[] args)
        {
            for (int kk = 0; kk < 10; kk++)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < 100; i++)
                    tmp.Add(i);
                int sum = 0;
                long start = DateTime.Now.Ticks;
                for (int i = 0; i < 1000000; i++)
                    sum += tmp.Find(delegate(int x) { return x == 3; });
                Console.WriteLine("Anonymous delegates: " + (DateTime.Now.Ticks - start));
                start = DateTime.Now.Ticks;
                sum = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    int match = 0;
                    for (int j = 0; j < tmp.Count; j++)
                    {
                        if (tmp[j] == 3)
                        {
                            match = tmp[j];
                            break;
                        }
                    }
                    sum += match;
                }
                Console.WriteLine("Classic C++ Style: " + (DateTime.Now.Ticks - start));
                Console.WriteLine();
            }
        }
