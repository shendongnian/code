    public class ProductController : Controller {
       [HttpGet]
       public ActionResult Index() {
          var productList = ProductService.GetProducts();
          return View( productList );
       }
    
       [HttpGet]
       public ActionResult Edit( int id ) {
          var product = ProductService.GetProduct( id );
          return View( product );
       }
    
       [HttpPost]
       public ActionResult Edit( ProductModel product ) {
          if (ModelState.IsValid()) {
             // save the changes
             return RedirectToAction( "Index" );
          }
          return View( product );
       }
    }
