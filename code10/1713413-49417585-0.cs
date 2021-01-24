    static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    public static async Task MethodAsync(int i)
    {
        Console.Write("<");
        if (await semaphore.WaitAsync(TimeSpan.Zero))
        {
             MethodA(i);
             await MethodB(i);
             MethodC(i);
             semaphore.Release();
        }
		
        Console.Write(">");
    }
