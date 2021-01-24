    public static void Main(string[] args)
    {
        Console.WriteLine("string");
        var threads = new Thread[5];
        for (int i = 0; i < threads.Length; ++i)
        {
            threads[i] = new Thread(() => {
                Thread.Sleep(1000);
                Console.WriteLine("smth");
            }) { IsBackground = true };
            threads[i].Start();
        }
    }
