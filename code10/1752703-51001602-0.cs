    public async Task<Something> AwaitTheTask()
    {
        using (var someResource = GetAResource())
        {
            return await SomeAsyncThing(someResource);
        }
    }
    public Task<Something> DontAwaitTheTask()
    {
        using (var someResource = GetAResource())
        {
            return SomeAsyncThing(someResource);
        }
    }
