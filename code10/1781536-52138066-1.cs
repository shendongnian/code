    using (var context = CreateContext())
    {
        // Remove old items
        DeleteItems(context, item => item.StockId == stock.Id);
    
        // Remove optional items from another stock
        DeleteItems(context, item => item.StockId == stock.RelatedStock.Id);
 
        // The rest...  
    }
