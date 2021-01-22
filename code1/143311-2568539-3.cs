    var paypalItems = new List<PaymentDetailsItemType>();
    
    foreach (var orderitem in order.OrderItems)
    {
        paypalItems.Add(new PaymentDetailsItemType
        {
            Name = orderitem.Name,
            Amount = ApiUtility.CreateBasicAmount(orderitem.Price),
            Description = orderitem.Name,
            Number = orderitem.Sku,
        });
    }
    
    if (giftCardsTotal != 0)
    {
        // add Coupons & Discounts line item
        paypalItems.Add(new PaymentDetailsItemType
        {
            Name = "Gift Cards",
            Amount = ApiUtility.CreateBasicAmount(giftCardsTotal),
            Description = "Gift Cards"
        });
    }
