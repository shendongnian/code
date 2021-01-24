    var bag = new ConcurrentBag<string>();
    var actionBlock = new ActionBlock<int> (async i => 
       bag.Add(await Process(i))
    );
    for(int i = 0; i < 100; i++)
    {
        actionBlock.Post(i);
    }
    actionBlock.Complete();
    await actionBlock.Completion;
