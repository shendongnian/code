    int successEntryCount = 0,
        failedEntryCount = 10,
        l = Console.CursorLeft,
        t = Console.CursorTop;
    for (int i = 0; i < 2000; i++)
    {
        Thread.Sleep(100);
        Console.SetCursorPosition(l, t);
        Console.WriteLine("success :{0}", successEntryCount++);
        Console.WriteLine("fail:{0}", failedEntryCount++);
        //or
        //Console.Write("success :{0} fail:{1}", successEntryCount++ , failedEntryCount++);
    }
