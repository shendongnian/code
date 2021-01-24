    [HttpPost]    
    public async Task<IActionResult> ExternalLogin([FromForm] ExternalLoginModel formModel, [FromBody] ExternalLoginModel bodyModel)
    {
        ExternalLoginModel model;
    
        // need to check if it is actually a form content type, as formModel may be bound to an empty instance
        if (Request.HasFormContentType && formModel != null)
        {
            model = formModel;
        }
        else if (bodyModel != null)
        {
            model = bodyModel;
        }
    
        ...
