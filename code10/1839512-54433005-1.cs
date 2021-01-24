    [HttpGet]
    public IActionResult GetProductById(int id)
    {
        Product product = _repository.GetProductById(id);
        if(product == null)
        {
            return NotFound(); // Here is one return type
        }
        return Ok(product);  // Here is another return type
    }
