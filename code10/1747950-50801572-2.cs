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
    
            // Note we are now returning the object directly, there is an implicit conversion 
            // done for you
            return configuration;
        }
        catch (Exception ex)
        {
            ... // Some code here
        }
    }
