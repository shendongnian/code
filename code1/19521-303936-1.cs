    for( int i = 0; i < _numOrders; i++ )
    {
        OrderTicket ticket = new OrderTicket(... );
        ticket.CacheId = Guid.NewGuid();
        Submit( ticket );  // note that this simply makes a remoting call
    }
