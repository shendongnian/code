    public void getOrderProductDetails
    {
        var data = _productRepository
            .Where(x => x.User == user)
            .OrderByDescending(x => x.ArrivalDate)
            .FirstOrDefault();
        // process data ...
    }
