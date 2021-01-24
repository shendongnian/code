    private static object methodLocker = new object();
    private static void WaitAndWriteMessage(TimeSpan waitTime, string message)
    {
        // Lock on a common object, so this call will wait
        // until there are no locks before it can continue
        lock (methodLocker)
        {
            Thread.Sleep(waitTime);
            Console.Write($"Method ran at: {DateTime.Now.ToString("hh:mm:ss")}. ");
            Console.WriteLine(message);
        }
    }
