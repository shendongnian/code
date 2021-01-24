    public class testClass
    { 
        public bool InStock { get; set; }
    }
     
    public ActionResult UserPermission(testClass Product)
    {
        ViewBag.Product=Product;
        //Product.InStock filled true if yes option is selected
        return View()
    }
