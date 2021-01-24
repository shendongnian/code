    async Task MyProducer(ITargetBlock<string> target)
    {
        ...
        await target.SendAsync(..);
        ...
        target.Complete();
    }
    async Task MyConsumer(ISourceBlock<string> target)
    {
        ...
        var message=await target.ReceiveAsync();
        ...
    }
    public static async Task Main()
    {
        var buffer=new BufferBlock<string>();
        MyProducer(buffer);
        await MyConsumer(buffer);
    }
