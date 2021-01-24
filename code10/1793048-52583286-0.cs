    [HttpPost]
    public async Task<IHttpActionResult> Post([FromBody]Job model) {
        if(ModelState.IsValid) {
            //...do something with model
            return Ok(model.ResourceUrl);
        }
        return BadRequest(ModelState);
    }
