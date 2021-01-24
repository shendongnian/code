    [HttpGet]
    public List<Product> Get()
    {
        return _repository.GetProducts();
        // Here you can not return Ok(products), NotFound() etc;
        // If you need to return NotFound() etc then use `IActionResult` instead of Specific type.
    }
    
