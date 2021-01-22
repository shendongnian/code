    var products = Entities.Products.WhereActive();
    return (
        from product in products
        let latestOrder = product.Orders.WhereActive().FirstOrDefault(
            candidateOrder => (
                candidateOrder.Date == product.Orders.WhereActive().Max(maxOrder => maxOrder.Date)
            )
        )
        select new Product()
        {
            Id = product.Id,
            Name = product.Name,
            LatestOrder = new Order()
            {
                Id = latestOrder.Id,
                Amount = latestOrder.Amount,
                Date = latestOrder.Date
            }
        }
    );
