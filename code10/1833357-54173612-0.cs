    private static void Main()
    {
        int n = 99;
        int[] buffer = new int[n];
        Random rnd = new Random();
        for (int i = 2; i < buffer.Length; i += 3)
        {
            int k = rnd.Next(1, 30);
            buffer[i] = k;
            buffer[i - 1] = k;
            buffer[i - 2] = k;
        }
        foreach (int t in buffer)
        {
            Console.Write(t + " ");
        }
        Console.ReadKey();
    }
