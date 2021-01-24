    [DllImport("Kernel32.dll"), SuppressUnmanagedCodeSecurity]
    public static extern int GetCurrentProcessorNumber();
     
    static void Main(string[] args)
    {
        Parallel.For (0, 10 , state => Console.WriteLine("Thread Id = {0}, CoreId = {1}",
            Thread.CurrentThread.ManagedThreadId,
            GetCurrentProcessorNumber()));
        Console.ReadKey();
    }
