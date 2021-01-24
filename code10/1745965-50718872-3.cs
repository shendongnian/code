    int successEntryCount = 0;
    int failedEntryCount = 10;
    for (int i = 0; i < 2000; i++)
    {
        Thread.Sleep(100);
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("success :{0}", successEntryCount++);
        Console.WriteLine("fail:{0}", failedEntryCount++);
        //or
        //Console.Write("success :{0} fail:{1}", successEntryCount++ , failedEntryCount++);
    }
