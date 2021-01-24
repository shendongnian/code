    private static void Main()
    {
        for(int i = 0; i < 3; i++)
        {
            Task.Run(() => WaitAndWriteMessage(TimeSpan.FromSeconds(5), 
                $"Message sent at {DateTime.Now.ToString("hh:mm:ss")}."));
            Thread.Sleep(1000);
        }
        Console.ReadKey();
    }
