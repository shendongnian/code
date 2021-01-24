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
    
       List<ProductSpecification> productSpecificationsToBeDeleted = productToBeUpdated.ProductSpecifications.Where(c1 => product.ProductSpecifications.All(c2 => c2.ProductAttributeValueId != c1.ProductAttributeValueId)).ToList();
       foreach (ProductSpecification productSpecification in productSpecificationsToBeDeleted)
       {
                    productToBeUpdated.ProductSpecifications.Remove(productSpecification);
       }
    
       List<ProductSpecification> productSpecificationsToBeAdded = product.ProductSpecifications.Where(c1 => productToBeUpdated.ProductSpecifications.All(c2 => c2.ProductAttributeValueId != c1.ProductAttributeValueId)).ToList();
       foreach (ProductSpecification productSpecification in productSpecificationsToBeAdded)
       {
                    productToBeUpdated.ProductSpecifications.Add(productSpecification);
       }
    
       productToBeUpdated.ModifiedOn = DateTime.UtcNow;
       await _unitOfWork.SaveChangesAsync();
       return Ok(true);
    }
