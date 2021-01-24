    [Route("api/orders")]
    [HttpPost]
    public async Task ProcessOrder([FromBody] Order order)
    {
        var orders = new List<Order>();
        orders.Add(order);
        // and some other code ...
    }
