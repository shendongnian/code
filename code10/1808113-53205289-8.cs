    public IHttpActionResult Post([FromBody]PostProductModel value) {
        if(ModelState.IsValid) {
            var result = _data.Products.Where(y => y.Id == value.productId).ToList();        
            return Ok(result);
        }
        return BadRequest(ModelState);
     }
