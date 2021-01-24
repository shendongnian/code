    public class ValuesController : ApiController
        {
            public ValuesController(OrderManager orderManager)
            {
                this.OrderManager = orderManager;
            }
    
            public OrderManager OrderManager { get; set; }
    
    
            [Route("orders")]
            public IHttpActionResult GetAll()
            {
                return Ok("Received");
            }
    
            [Route("orders/{id}")]
            public OrderViewModel Get(int id)
            {
                var order = OrderManager.GetOrder(id);
    
                var orderViewModel = new OrderViewModel
                {
                    Header = order.Header,
                    Description = order.Description,
                };
    
                return orderViewModel;
            }
