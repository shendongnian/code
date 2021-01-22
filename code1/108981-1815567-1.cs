    var repo = new Repository();
    var entities = repo.GetAllEntities();
    foreach (var entity in entities)
    {
        var entityCustomers = entity.Customers;
        var entityOrders = entity.Orders;
        var invoices = entityOrders.Invoices;
        ThreadPool.QueueUserWorkItem(
            delegate
            {
                try
                {
                     ProcessEntity(entity);
                }
                catch (Exception)
                {
                    throw;
                }
            });
    }
