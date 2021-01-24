    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context; //database context
        public ProductController(ApplicationDbContext context)
        {
            _context = context; //context for controller
        }
        //GET
        public ActionResult Index()
        {
            ProductViewModel productVM = new ProductViewModel(); //viewmodel instance
            productVM.Products=PopulateProducts(); //populating dropdown
            return View(productVM); //returning viewmodel
        }
        //POST (I belive that here I have screwed something a lot, I do not understand everything what is going on in this action)
        [HttpPost]
        public ActionResult Index(ProductViewModel productVM)
        {
            productVM.Products= PopulateProducts();
            if (productVM.ProductIDs != null)
            {
                List<SelectListItem> selectedItems = productVM.Products.Where(p => productVM.ProductIDs.Contains(int.Parse(p.Value))).ToList();
                ViewBag.Message = selectedItems.Count.ToString(); //returns 0
                ViewBag.Message2 = productVM.Products.Count.ToString();//returns 0
            }
            return View(productVM);
        }
        private List<SelectListItem> PopulateProducts() //method populating dropdown list
        {
            var techQuery = from t in _context.Products //getting products context from database
                orderby t.Name //sorting by names
                select t; //selecting item (??)
            if (techQuery != null) //if db context var is not null...
            {
                return techQuery.Select(n => new SelectListItem { Text = n.Name, Value = n.ProductID.ToString() }).ToList(); //...creating viewbag that is used for populating dropdown list in view
            }
            return null;
        }
    }
