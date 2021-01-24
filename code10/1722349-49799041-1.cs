    var exists = await _productRepository.GetAll().AnyAsync(c => c.Id == input.Id); // Change
    if (!exists)                                                                    // this
        throw new UserFriendlyException(L("ProductNotExist"));
    var updatedEntity = ObjectMapper.Map<Product>(input);
    var entity = await _productRepository.UpdateAsync(updatedEntity);
