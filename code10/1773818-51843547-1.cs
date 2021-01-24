    [HttpPost("data/save")]
    public async Task<IActionResult> SaveData([FromBody] List<UserData> data)
    {
    	if (!ModelState.IsValid)
    		return BadRequest(ModelState); //will return a 400 code
    	...
