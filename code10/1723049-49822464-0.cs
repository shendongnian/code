    [UnitOfWork]
    public virtual async Task<ProductDto> CreateProduct(CreateProductInput input)
    {
        var existing = await _productManager.Products
            .Where(p => p.Name == input.Name)
            .FirstOrDefaultAsync();
        // ...
    }
