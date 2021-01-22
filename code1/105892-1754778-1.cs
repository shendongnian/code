    public IQuerable<Order> GetOrdersBySellerId(int sellerId)
    {
        return ActiveRecordLinq.AsQueryable<Order>()
                   .Where(x=>x.Items.Count > 0 && x.Items.First().Seller.SellerID == sellerId)();
    }
