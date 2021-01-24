    using (var dbContext = new MyDbContext(...))
    {
        // remove all Deleted products of the form with Code equal to fCode
        // and SCode equal to sCode
        var productsToDelete = dbContext.Products
            .Where(product => product.Deleted
                && product.Form.Code == fCode
                && product.Form.Scode == sCode);
        // note: query is not executed yet!
        dbContext.Products.RemoveRange(productsToDelete);
        dbContext.SaveChanges();
    }
