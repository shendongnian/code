    public virtual async Task<Product> CreateProduct(Product input)
    {
    	using (var uow = _unitOfWorkManager.Begin())
    	{
            var result = await _ProductRepository.InsertAsync(input);
            await _unitOfWorkManager.Current.SaveChangesAsync();
    		await uow.CompleteAsync();
            return result;
    	}
    }
