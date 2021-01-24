    namespace ProjectA.Controllers {
		public partial class CustomerController : Controller
		{
			public virtual IActionResult Index()
			{
				...Some code here
			}
			public virtual IActionResult Login()
			{
				...Some code here
			}
		}
	}
	namespace ProjectB.Controllers {
		public partial class CustomCustomerController : ProjectA.Controllers.CustomerController
		{
			public override IActionResult Login()
			{
				...Some code here
			}
		}
	}
