    public class MyController : Controller 
    { 
        public OrderService OrderService {get; set;} 
     
        protected override void OnActionExecuting(...) 
        { 
            OrderService orderService = new OrderService();
            Order myOrder = orderService.GetOrder(orderId);
            
            // Some stuff here
            orderService.AddProduct(myOrder, selectedProduct);
        } 
    } 
