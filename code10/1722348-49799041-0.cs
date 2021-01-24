    var exists = await _productRepository.GetAll().AnyAsync(c => c.Id == input.Id);
    if (!exists)
    {
        throw new UserFriendlyException(L("ProductNotExist"));        // No change
    }
    var updatedEntity = ObjectMapper.Map<Product>(input);             // No change
    var entity = await _productRepository.UpdateAsync(updatedEntity); // No change
