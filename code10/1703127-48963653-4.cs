    public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
           return BadRequest(ModelState);
        }
    
        if (id != product.ProductId)
        {
           return BadRequest();
        }
    
        Product productToBeUpdated = await _unitOfWork.Repository<Product>().GetEntityList(p => p.ProductId == id).Include(p => p.ProductSpecifications).SingleOrDefaultAsync();
        if (productToBeUpdated == null)
        {
            return NotFound();
        }
    
        _mapper.Map(product, productToBeUpdated); // If you use AutoMapper than ignore the many-to-many navigation property in the mapping
    
       List<ProductSpecification> productSpecificationsToBeDeleted = productToBeUpdated.ProductSpecifications.Except(product.ProductSpecifications, (c1, c2) => c1.ProductAttributeValueId == c2.ProductAttributeValueId).ToList();
       foreach (ProductSpecification productSpecification in productSpecificationsToBeDeleted)
       {
                    productToBeUpdated.ProductSpecifications.Remove(productSpecification);
       }
    
       List<ProductSpecification> productSpecificationsToBeAdded = product.ProductSpecifications.Except(productToBeUpdated.ProductSpecifications, (c1, c2) => c1.ProductAttributeValueId == c2.ProductAttributeValueId).ToList();
       foreach (ProductSpecification productSpecification in productSpecificationsToBeAdded)
       {
                    productToBeUpdated.ProductSpecifications.Add(productSpecification);
       }
    
       productToBeUpdated.ModifiedOn = DateTime.UtcNow;
       await _unitOfWork.SaveChangesAsync();
       return Ok(true);
    }
