    //Assuming your return type is `Configuration`
    public async Task<ActionResult<Configuration>> GetConfiguration([FromRoute] int? id)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
    
            ..... // Some code here
    
            return Ok(configuration);
        }
        catch (Exception ex)
        {
            ... // Some code here
        }
    }
