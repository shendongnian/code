    static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    public static async Task MethodAsync()
    {
        Console.Write("<");
        if (await semaphore.WaitAsync(TimeSpan.Zero))
        {
             MethodA();
             await MethodB();
             MethodC();
             semaphore.Release();
        }
		
        Console.Write(">");
    }
