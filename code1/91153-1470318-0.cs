    public class Controller
    {
        private CustomerService _customerService; // Perhaps injected by an IoC container?
    
        public ActionResult SomeAction(int id)
        {
            return Json(_customerService.GetCustomerById(id));
        }
    }
