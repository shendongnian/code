    [HttpGet("customers/{customerId}/orders/{orderId}")]
    public Order FindOneOrder(int customerId, int orderId) //including orderId
    {   
        return OrderRepository.GetByOrderid(customerId, orderId);
    }
    
    [HttpGet("customers/{customerId}/orders")]
        public List<Order> GetCustomerOrders(int customerId) // using customerId
    {
      return OrderRepository.GetAllOrders(customerId);
    }
