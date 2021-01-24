    public static async Task Task1()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.WriteLine("Task1 " + i);
            await MyFunc();
        }
    }
    public static async Task Task2()
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.WriteLine("Task2 " + i);
            await MyFunc();
        }
    }
