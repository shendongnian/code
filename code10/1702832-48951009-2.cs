    [HttpGet]
    [ActionName("ByName")]
    [Route("api/Products/ByName/{name}")]
    public IHttpActionResult GetProductByName(string name)
    {
        var product = this.m_products.FirstOrDefault(x => x.Name == name);
        return product == null ? (IHttpActionResult) NotFound() : Ok(product);
    }
