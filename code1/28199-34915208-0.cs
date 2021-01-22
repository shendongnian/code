    public class ProductController : Controller
    {
        public object Index(int? page)
        {
            var list = ItemDB.GetListOfItems();
    
            var pageNumber = page ?? 1; 
            var onePageOfItem = list.ToPagedList(pageNumber, 25); // will only contain 25 items max because of the pageSize
    
            ViewBag.onePageOfItem = onePageOfProducts;
            return View();
        }
    }
 
