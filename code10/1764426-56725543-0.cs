    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> GetById(int id)
    {
        if (!_repository.TryGetProduct(id, out var product))
        {
            return NotFound();
        }
        return product;
    }
