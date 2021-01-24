    [ApiController]
    public class OrderController : ControllerBase
    {
            [HttpPost("api/order")]
            public async Task<IActionResult> SaveOrder(SaveOrderModel model)
            {
                ...
    
            }
    
            [HttpGet("order/customerorders")]
            public async Task<IActionResult> CustomerOrders()
            {
               if (!User.IsInRole("Customer"))
                  return Challenge();
               var customer = await _workContext.CurrentCustomer();
    
               var model = await orderModelFactory.PrepareCustomerOrderListModel();
               return View(model);
            }
    }
