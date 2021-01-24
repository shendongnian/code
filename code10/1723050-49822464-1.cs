<!-- -->
    [UnitOfWork]
    public virtual async Task<Product> CreateProduct(Product input)
    {
        var result = await _ProductRepository.InsertAsync(input);
        await _unitOfWorkManager.Current.SaveChangesAsync();
        return result;
    }
