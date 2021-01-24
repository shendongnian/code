    public  List<Product> GetProductWithCategories()
    {
        using (DenemeContext context=new DenemeContext())
        {
            var query = (from pro in context.Products
                   join cat in context.Categories
                   on pro.CategoryId equals cat.CategoryId
                   select new Product
                   {
                       ProductID = pro.ProductId,
                       ProductName = pro.ProductName,
                       ProductCategor = cat.CategoryName
                   }).ToList();
            return query.ToList();
        }
    }
