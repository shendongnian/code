    public class OrderController : Controller {
        //...removed for brevity
   
        //POST "customers/578/orders/1576/overview
        [HttpPost("customers/{customerId}/orders/{orderId}/overview")]
        public IActionResult Post(string customerId, string orderId) {
            var order = orderRepository.CreateNewCustomerOrder(customerId, orderId);
            if(order == null) {
                return BadRequest();
            }
            //return 201 created status code along with 
            //the route name, route value, and the actual object that is created
            return CreatedAtRoute("GetOrder", new { orderId = order.OrderId }, order);
        }
        
        //GET orders/157
        [HttpGet("orders/{orderId}", Name = "GetOrder")]
        public IActionResult GetOrder(string orderId) {
            var order = orderRepository.GetOrder(orderId);
            if(order == null) {
                return NotFound();
            }
            return Ok(order);
        }
    }
