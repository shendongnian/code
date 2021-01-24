    public class HomeController : Controller
    {
        private EditProductViewModel viewModel;
        public HomeController()
        {
            this.viewModel = new EditProductViewModel();
            InitialiseViewModel();
        }
        public ActionResult Index()
        {
            return View("Index", viewModel);
        }
        private void InitialiseViewModel()
        {
            ProductCategoryModel productCategoryModel = new ProductCategoryModel();
            ProductModel productModel = new ProductModel();
            //do your mapping 
            productModel.Name = "Test mapping";
            this.viewModel.Product = productModel;
        }
    }
