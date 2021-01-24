    private async Task<bool> WriteTest(int delay)
    {
        bool run = true;
        while (run)
        {
                //Write to DB
                await db.ravenDB.CreateDocument();
                await Task.Delay(delay);
        }
        return true;
    }
    public async Task CreateDocument()
    {
        using (var session = Store.OpenAsyncSession())
        {
            await session.StoreAsync(new TestObject
            {
                Name = "TestObjectName",
                RandomNumber = 123
            });
            await session.SaveChangesAsync();
        }
    }
