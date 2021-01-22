    IList<string> ordersToGetUpdate = new List<string> { serialNumber };
    
    NotificationHistoryRequest request = new NotificationHistoryRequest(ordersToGetUpdate);
    NotificationHistoryResponse resp = (NotificationHistoryResponse)request.Send();
    
    foreach (object notification in resp.NotificationResponses)
    {
        // You'd now need to handle the response, which could be one of NewOrderNotification, OrderStateChangeNotification, RiskInformationNotification, AuthorizationAmountNotification or a ChargeAmountNotification
        NewOrderNotification newOrder = notification as NewOrderNotification;
        if( newOrder != null )
        {
            // Yay! New order, so do "something" with it
        }
        OrderStateChangeNotification orderUpdate = notification as OrderStateChangeNotification;
        if (orderUpdate != null)
        {
             // Order updated (paid, shipped, etc), so do "something" with it
        }
        // you probably get the idea as to how to handle the other response types
    }
