    [HttpPost("data/save")]
    public async Task<IActionResult> SaveData([FromBody] List<UserData> data)
    {
    	if (!ModelState.IsValid)
    		return BadRequest(ModelState); //400 status code
    	
    	try
    	{
    		SaveData(data);
    	}
    	catch(Exception e)
    	{
    		return InternalServerError(e); //500 status code
    	}
    	
        string someDataToReturn = string.Empty;
    	return Ok(someDataToReturn ); //200 status code
    }
    
    public void SaveData(List<UserData> data)
    {           
    	foreach (var set in data)
    	{
    		//creating query etc
    
    	   _db.Execute(query);
    	}                
    }
