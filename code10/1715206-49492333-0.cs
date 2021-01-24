    [HttpPost]
    [ActionName("cancel")]
    public async Task<Response> Cancel([FromBody]Order order) {
        if(ModelState.IsValid) {
            int orderId = order.OrderId;
            ICollection<int> ids = order.Ids;
            //...
        }
        //...
    }
    
