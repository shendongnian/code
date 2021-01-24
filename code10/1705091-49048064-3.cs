    public void Post(ItemAndChecque request)
    {
        var productRepository = new ProductRepository();
        var newProduct = productRepository.Save(request.product);
    }
