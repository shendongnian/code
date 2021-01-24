    private ConcurrentDictionary<string, ...> _orderData = 
        new ConcurrentDictionary<string, ...>();
    
    public bool PlaceNewOrder(...)
        {
            string clOrdID = ...;
            QuickFix.FIX44.NewOrderSingle msgOrder = 
                new QuickFix.FIX44.NewOrderSingle(new ClOrdID(clOrdID), ...);
            ...;
            _orderData.TryAdd(clOrdID, <data required for later processing>);
            // Notice the data is stored before sending the message
            // so it will be available to process a response
            Session.SendToTarget(msgOrder, sessionID);
        }
