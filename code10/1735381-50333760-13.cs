	ProductQuery filter = ... // initialize here
    var exprs = new List<Expression<Func<Product, bool>>>() {
        p => p.CategoryId == filter.CategoryId,
        p => p.Price >= filter.MinPrice,
        p => p.Price <= filter.MaxPrice
    };
    foreach (var expr in exprs) {
        var pi = ((expr.Body as BinaryExpression)
            .Right as MemberExpression)
            .Member as PropertyInfo;
        if (pi.GetValue(filter) != null) {
            products = products.Where(expr);
        }
    }
