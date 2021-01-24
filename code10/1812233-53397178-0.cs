    [HttpGet("")]
    public async Task<ContentResult> ExecuteGET([FromQuery] string query, [FromQuery] string variables = null, [FromQuery] string operationName = null)
     {
        //Put your execute code here...
    }
