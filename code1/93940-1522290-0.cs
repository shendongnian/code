    public static void PerformBlinks()
    {
        var random = new Random();
        for (int i = 0; i < 300; i++)
        {
            if (random.Next(10) == 0)
            {
                BlinkGreen();
            }
            else
            {
                BlinkRed();
            }
            // Pause the thread for 2 seconds.
            Thread.Sleep(2000);
        }
    }
