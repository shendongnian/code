    const int SIZE = 10000000, LOOPS = 80000;
    byte[] array = Enumerable.Repeat(0, SIZE).Select(i => (byte)r.Next(10)).ToArray();
    int[] visitOrder = Enumerable.Repeat(0, LOOPS).Select(i => r.Next(SIZE)).ToArray();
    
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    sw.Start();
    int sum = 0;
    foreach (int v in visitOrder)
        sum += array[v];
    sw.Stop();
