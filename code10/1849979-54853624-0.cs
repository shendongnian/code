    namespace WebApplication1.Controllers
    {
        public class CustomerMetaDta
        {
            [Remote("IsEmailExists", "Customer", ErrorMessage = "EmailId already exists.")]
            [Required(ErrorMessage = "Please Enter Emailw")]
            public string CustomerEmail { get; set; }
        }
    
        [MetadataType(typeof(CustomerMetaDta))]
        public partial class Customer
        {
    
        }
    
        public partial class Customer
        {
            public string CustomerEmail { get; set; }
            public string CustomerName { get; set; }
            public string PasswordHash { get; set; }
        }
        public class CustomerController : Controller
        {
            public JsonResult IsEmailExists(string CustomerEmail)
            {
                //emedicineEntities _db = new emedicineEntities();
                List<Customer> _db = new List<Customer>
                {
                    new Customer { CustomerEmail  = "hien@gmail.com"},
                    new Customer { CustomerEmail  = "hien1@gmail.com"}
                };
                return Json(!_db.Any(x => x.CustomerEmail == CustomerEmail), JsonRequestBehavior.AllowGet);
            }
            // GET: Customer
            public ActionResult Index()
            {
                return View();
            }
        }
    }
