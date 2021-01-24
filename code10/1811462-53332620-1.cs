    var workerBlock = new ActionBlock<Info>(async info => 
    {
        try
        {
            name = await commonValidator.ValidateAsync(name);
            await commonValidator.ValidateIdAsync(name, id);
            var list = await helper.ListRelatedObjectsAsync(name, id, info, false);
            //Note this is not thread safe and you need to put a lock around it.
            lock (secondaryObjectsDictionaryCollection) 
            {
                secondaryObjectsDictionaryCollection.Add(info.PrimaryId, secondaryObjectsList.ToList());
            }
        }
        catch (Exception ex)
        {
            exceptions.Enqueue(ex);
        }
    }, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded });
    foreach(var info in infos)
    {
        workerBlock.Post(info);
    }
    workerBlock.Complete();
