    static void Main(string[] args)
    {
        List<int> intList = new List<int>();
        Console.WriteLine("Generating data.");
        for (int i = 0; i < 134217728 ; i++)
        {
            intList.Add(i);
        }
        Console.Write("Calculating for loop:\t\t");
        Stopwatch time = new Stopwatch();
        time.Start();
        for (int i = 0; i < intList.Count; i++)
        {
            int foo = intList[i] * 2;
            if (foo % 2 == 0)
            {
            }
        }
        time.Stop();
        Console.WriteLine(time.ElapsedMilliseconds.ToString() + "ms");
        Console.Write("Calculating foreach loop:\t");
        time.Reset();
        time.Start();
        foreach (int i in intList)
        {
            int foo = i * 2;
            if (foo % 2 == 0)
            {
            }
        }
        time.Stop();
        Console.WriteLine(time.ElapsedMilliseconds.ToString() + "ms");
        Console.Read();
    }
