    public class MyController : Controller 
    {    
        public IOrderService OrderService { get; private set; }
        public MyController(IOrderService orderService)
        {
            OrderService = orderService ?? new DaoOrderService();
        }
        public MyController()
            : this(null)
        { }
        protected override void OnActionExecuting(...) 
        {             
            Order myOrder = OrderService.GetOrder(orderId);
            
            // Some stuff here
            orderService.AddProduct(myOrder, selectedProduct);
        } 
    } 
