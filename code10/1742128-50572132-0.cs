    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
         if(!ModelState.IsValid)
         {
             return BadRequest();
         }
         return Ok();
    }
