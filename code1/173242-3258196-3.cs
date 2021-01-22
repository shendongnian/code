    public class OrderController : Controller
    {    
        private readonly IOrderConfirmService _service;
        
        public OrderController(IOrderConfirmService service)
        {        
            _service= service;        
        }
        
        public ActionResult Confirm()
        {      
                _service.EmailOrderConfirmation(some order);
                return View();
        }    
    }
