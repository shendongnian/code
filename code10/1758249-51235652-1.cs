    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using ben22.Repositories;
    using ben22.Models.Models;
    
    namespace ben22.Controllers
    {
        public class OrderController : Controller
        {
            [HttpPost("customers/{customerId}/orders/{orderId}/overview")]
            public IActionResult Post([FromRoute] string customerId, string orderId, [FromBody] Order order)
            {
                OrderRepository.SaveNewCustomerOrder(customerId, orderId, new Order());
    
                return Ok();
            }
        }
    }
