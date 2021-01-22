    public class ProductsController : Controller
    {
        private readonly NorthwindDataContext northwind = new NorthwindDataContext(
            ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString );
      
        public ActionResult Edit( int id )
        {
            var viewData = new ProductsEditViewData { Product = northwind.GetProductById( id ) };
            viewData.Categories = new SelectList( northwind.GetCategories(), "CategoryID", "CategoryName", viewData.Product.CategoryID );
            viewData.Suppliers = new SelectList( northwind.GetSuppliers(), "SupplierID", "CompanyName", viewData.Product.SupplierID );
            return View( "Edit", viewData );
        }
    }
