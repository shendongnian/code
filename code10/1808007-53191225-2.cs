     public ActionResult GetStuff()
        {
            var orderModel = ....; // do your thing to get your order
            var responseObj = Mapper.Map<OrderDto>(orderModel);
            return StatusCode(200, responseObj); 
        }
