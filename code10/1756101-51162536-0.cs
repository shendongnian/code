    public async Task<Order> CreateAsync(Order order)
    {
        _dbContext.OrderBook.Add(order);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateException ex)
        {
            _dbContext.OrderBook.Remove(order);
            throw ex;
        }
        return order;
    }
