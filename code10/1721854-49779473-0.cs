    private static void Modify()
    {
        var product = ctx.Products.FirstOrDefault(p => p.Name == "Product 1");
        product.Status = Status.Used;
        ctx.Entry(product).State = EntityState.Modified;
        ctx.SaveChanges();
        ctx.Refresh(RefreshMode.OverwriteCurrentValues, product);
        product = ctx.Products.FirstOrDefault(p => p.Name == "Product 1");
    }
