    public class CustomerController : Controller
        {
            //
            // GET: /Customer/
    
            public ActionResult LoadCustomer()
            {
                return Content("LoadCustomer");
            }
            
            [ActionName("LoadCustomerbyName")]
            public ActionResult LoadCustomer(string str)
            {
                return Content("LoadCustomer with a string");
            }
        }
