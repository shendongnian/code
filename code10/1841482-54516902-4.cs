    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult<Product> GetById(int id)
    {
        if (!_repository.TryGetProduct(id, out var product))
        {
            return NotFound();
        }
    
        return product;
    }
