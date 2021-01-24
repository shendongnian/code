    [HttpPost("create", Name = "CreateSalesRecord")]
    public IActionResult Create([FromBody] SalesRecord record) {
        if(ModelState.IsValid) {
            //...
            return Ok();
        }
        
        return BadRequest(ModelState);
    }
    
