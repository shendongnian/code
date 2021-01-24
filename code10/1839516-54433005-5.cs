    [HttpGet]
    public async Task<IActionResult> GetProductById(int id)
    {
        Product product = await _repository.GetProductByIdAsync(id);
        if(product == null)
        {
            return NotFound(); // Here is one return type
        }
        return Ok(product);  // Here is another return type
    }
