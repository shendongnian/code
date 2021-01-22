    public interface IViewDataFactory
    {
        T Create<T>()
            where T : MasterViewData, new()
    }
    public class ProductController : Controller
    {
        public ProductController(IViewDataFactory viewDataFactory)
        ...
        public ActionResult Index()
        {
            var viewData = viewDataFactory.Create<ProductViewData>();
            viewData.Name = "My product";
            viewData.Price = 9.95;
            return View("Index", viewData);
        }
    }
