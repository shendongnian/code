    public ActionResult Products() {
        var productList = 
            (from p in db.Products
             join c in db.Categories 
             on p.CategoryID equals c.CategoryID
             select new ProductViewModel { 
                 ProductID = p.ProductID, 
                 ProductName = p.ProductName, 
                 CategoryName = c.CategoryName 
             }).ToList();
        var viewModel = new ProductsPageViewModel {
            ProductsList = productList 
        };
        return View("Products", viewModel);
    }
