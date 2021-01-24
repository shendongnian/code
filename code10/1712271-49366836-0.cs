    [HttpPost]
    public IActionResult Create([FromBody] RequestModel request) 
    {
         if (request == null || !ModelState.IsValid) 
         {
             return BadRequest(ModelState);
         }
         ...
