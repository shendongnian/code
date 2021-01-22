        static void Main(string[] args)
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < 10000000; i++)
            {
                intList.Add(i);
            }
            DateTime timeStarted = DateTime.Now;
            for (int i = 0; i < intList.Count; i++)
            {
                int foo = intList[i] * 2;
                if (foo % 2 == 0)
                {
                }
            }
            TimeSpan finished = DateTime.Now - timeStarted;
            Console.WriteLine(finished.TotalMilliseconds.ToString());
            Console.Read();
        }
