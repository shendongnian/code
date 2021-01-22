    List<Product> products = new List<Product>();
    products.Add(new Product() { ProductId = 1, Description = "Foo" });
    products.Add(new Product() { ProductId = 2, Description = "Bar" });
    var productQuery = products.Select(p => new { ProductId = p.ProductId, DisplayText = p.ProductId.ToString() + " " + p.Description });
    skuDropDown.DataSource = productQuery;
    skuDropDown.DataValueField = "ProductId";
    skuDropDown.DataTextField = "DisplayText";
    skuDropDown.DataBind();
