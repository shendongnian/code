    var p = new Product { Price = 30 };
    Expression<Func<Product, bool>> predicate = x => x.Price == p.Price;
    BinaryExpression eq = (BinaryExpression)predicate.Body;
    MemberExpression productToPrice = (MemberExpression)eq.Right;
    MemberExpression captureToProduct = (MemberExpression)productToPrice.Expression;
    ConstantExpression captureConst = (ConstantExpression)captureToProduct.Expression;
    object product = ((FieldInfo)captureToProduct.Member).GetValue(captureConst.Value);
    object price = ((PropertyInfo)productToPrice.Member).GetValue(product, null);
