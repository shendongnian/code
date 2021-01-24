    async Task Main()
    {
        await Test1();
    }
    
    public static async Task Test1()
    {
        await Task.Delay(1000);
        throw new Exception("Test");
    }
