    private async Task ProcessCollectionsAsync(DbContext context, IList<Order> ordersToCollect)
    {
        if (ordersToCollect.Count == 0) return;
        Log.Debug($"ProcessCollections: processing {ordersToCollect.Count} orders");
        foreach (var order in ordersToCollect)
        {
            // group the 3 operations in one transaction for each order
            // so that if one operation fails, the operations performend on the previous orders
            // are committed
            try
            {
                // *************************
                // run the 3 operations here
                // operations consist of updating the order itself, and other database updates
                Operation1(order);
                Operation2(order);
                Operation3(order);
                // *************************
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {                     
                Log.Error("General exception when executing ProcessCollectionsAsync on Order " + order.Id, ex);
                throw;
            }
        }
