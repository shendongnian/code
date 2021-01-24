    object items = new // <--
    {
        deliveryDay = DateTime.Today.AddDays(-1),
        deliveryDays = dr,
        AuctionIdentification = Ai
    };
    oi.Items = new object[1] { items };
 
