    int successEntryCount = 0;
    int failedEntryCount = 0;
    Console.WriteLine("App Started:");
    int left = Console.CursorLeft;
    int right = Console.CursorTop;
    foreach (var entity in entities)
    {
        var res = bll.AsiErtelemeIptalPaketiGonder(entity);
        if (res.State == Framework.Entities.MessageResultState.SUCCESS)
            successEntryCount++;
        else
            failedEntryCount++;
    
        Console.SetCursorPosition(left, right);
        Console.WriteLine("success :{0}", successEntryCount);
        Console.WriteLine("fail:{0}", failedEntryCount);
    }
