    async Task Function1(...)
    {
        using (var dbcontext = new MyDbContext(...))
        {
            // Start Fetching the item that must be changed; don't await yet
            var taskFetchItemToChange = dbContext.Items
                .Where(...)
                .FirstOrDefaultAsync();
            // Start fetching the orderId that must be changed; don't await yet
            var taskFetchOrderId = this.CallApiAsync();
            // await until both item and orderId are fetched:
            await Task.WhenAll(new Task[] {taskFetchItemToChange, taskFetchOrderId});
            var fetchedItemToChange = taskFetchItemToChange.Result;
            var fetchedOrderId = taskFetchOrderId.Result;
            fetchedItemToChange.OrderId = fetchedOrderId;
            // or do this in one big unreadable unmaintainable untestable step
            await dbContext.SaveChangesAsync();
        }
    }
