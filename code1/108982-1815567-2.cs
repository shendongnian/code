    var repo = new Repository();
    var entities = repo.GetAllEntities();
    foreach (var entity in entities)
    {
        var localEntity = entity; // Verify the callback uses the correct instance
        var entityCustomers = localEntity.Customers;
        var entityOrders = localEntity.Orders;
        var invoices = entityOrders.Invoices;
        ThreadPool.QueueUserWorkItem(
            delegate
            {
                try
                {
                     ProcessEntity(localEntity);
                }
                catch (Exception)
                {
                    throw;
                }
            });
    }
