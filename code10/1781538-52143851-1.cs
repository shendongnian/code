    public void Update(Stock stock)
    {
        using (var context = CreateContext())
        using (var transaction = context.Database.BeginTransaction())
        {
            // Remove optional items from another stock
            // This is principal record in the items relation
            var oldOptionalItems = context.Items
                                          .Where(item => item.StockId == stock.RelatedStock.Id)
                                          .Select(item => new Item { Id = item.Id })
                                          .ToList();
            context.Items.RemoveRange(oldOptionalItems);
            // Remove them actually from the database
            context.SaveChanges();
            // Remove old items
            var oldItems = context.Items
                              .Where(item => item.StockId == stock.Id)
                              .Select(item => new Item { Id = item.Id })
                              .ToList();
            context.Items.RemoveRange(oldItems);
            
            context.Stocks.Update(stock);
            context.SaveChanges();         
        }
    }
