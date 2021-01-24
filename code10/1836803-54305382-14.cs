    var propName = "STOCK"; // here you assign any value
    var constValue = "50";  // here you assign any value
    var param = Expression.Parameter(typeof(ProductModel), "p");
    var exp = Expression.Lambda<Func<ProductModel, bool>>(
        Expression.GreaterThan(
           Expression.Property(param, propName),
           Expression.Constant(constValue)
        ),
        param
    );
    var product = (from d in db.PRODUCTS
                       where query
                       select new ProductModel
                       {
                           Description= d.DESCRIPTION,
                           Brand= d.BRANDS.BRAND,
                           SefUrl = sef_url,
                           Name= d.NAME,
                       }).Where(exp);
