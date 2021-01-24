    private void AddOrder(int[] productIDs)
    {
        Order newOrder = new Order();
        newOrder.Name = "New Order";
    
        foreach (int productId in productIDs)
        {
            newOrder.Products.Add(new OrderProduct { ProductId = productId });
        }
        _dbContext.Orders.Add(newOrder);
        _dbContext.SaveChanges();
    }
