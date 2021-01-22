    public void AddProductToSession(Product product)
    {
      var products = Session["goods"] as Dictionary<int, Product>;
      if (products == null) products = new Dictionary<int, Product>();
      products.Add(product.ProductId, product);
      Session["goods"] = product;
    }
    public Product GetProductFromSession(int productId)
    {
      Product product;
      var products = Session["goods"] as Dictionary<int, Product>;
      if (products == null || !products.TryGetValue(productId, out product))
        throw Exception(string.Format("Product {0} not in session", productId));
      return product;
    }
