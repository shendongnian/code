    static async Task Main()
    {
        var maxConnections=20;
        var options=new ExecutionDataflowBlockOptions 
                    {
                        MaxDegreeOfParallelism = maxConnections,
                        BoundedCapacity        = maxConnections * 2
                    };
        var framework = new Sender();
        var myBlock=new ActionBlock<string>(url=>
                    {
                        framework.Send(...);
                    }, options);
        //ReadLines doesn't load everything, it returns an IEnumerable<string> that loads
        //lines as needed
        var lines = File.ReadLines("urls.txt");
        
        foreach(var url in lines)
        {
            //Send each line to the block, waiting if the buffer is full
            await myBlock.SendAsync(url);
        }
        //Tell the block we are done
        myBlock.Complete();
        //And wait until it finishes everything
        await myBlock.Completion;
    }
