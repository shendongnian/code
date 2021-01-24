    public static async Task Thread1()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.WriteLine("Thread1 " + i);
            await MyFunc();
        }
    }
    public static async Task Thread2()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.WriteLine("Thread2 " + i);
            await MyFunc();
        }
    }
