    private AnonType AnonMethod(Product product)
    {
        return new
            {
                ID = product.ID,
                Name = product.Name,
                Content = new Func<object,string>(
                    (obj) => (GetSomeDynamicContent(obj, product))
                    )
            };
    }
    var products = allProducts.Select(AnonMethod);
    someCustomWebControl.DataSource = products;
    someCustomWebControl.DataBind();
