    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        return await _repository.GetProductsAsync();
        // Here you can not return Ok(products), NotFound() etc;
        // If you need to return NotFound() etc then use `IActionResult` instead of Specific type.
    }
    
