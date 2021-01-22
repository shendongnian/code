    public IQuerable<Order> GetOrdersBySellerId(int sellerId)
    {
        return Order.Queryable
                   .Where(x=>x.Items.Count > 0 && x.Items.First().Seller.SellerID == sellerId)();
    }
