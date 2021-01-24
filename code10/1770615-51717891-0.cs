    public class BaseController : Controller
    {
        public ApplicationDbContext _db;
        public BaseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["MyKey"] = _db.Product.ToList();
            base.OnActionExecuting(context);
        }
    }
_LoginPartial.cshtml
    @foreach (Product item in @ViewData["MyKey"] as IList<Product>)
    {
        <li><a>@item.Name</a></li>
    }
