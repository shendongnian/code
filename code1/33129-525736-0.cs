    public class CategoryProduct
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories {get; set; }
    }
    ....
    return View( new CategoryProduct { Products = products,
                                       Categories = categories } );
