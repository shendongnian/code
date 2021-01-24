    public class MyObj
    {
        [Required]
        public string Foo { get; set; }
    }
    
    
    [HttpPost]
    public IActionResult Post([FromBody]MyObj obj)
    {
        if (obj == null)
        {
            return BadRequest();
        }
    
        if (!ModelState.IsValid)
        {
            return UnprocessableEntity(ModelState);
        }
    
        return Ok();
    }
