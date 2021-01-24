    [HttpPost]
    public IActionResult UpdateProductById([FromBody]ProductModel model) {
        if(ModelState.IsValid) {
            var result = ProductService.UpdateProductById(model.id, model.description);
            if (result.Exception == null)
                return Ok(result);
            else
                return BadRequest(result.Exception.Message);
        }
        return BadRequest(ModelState);
    }
