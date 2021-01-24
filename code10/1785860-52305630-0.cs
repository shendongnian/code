    public async Task<ActionResult> GetAccount2Async([FromHeader] string authorization) 
    {
        if (String.IsNullOrEmpty(authorization)) { /* */ }
        if (!authorization.StartsWith("accessToken",StringComparison.OrdinalIgnoreCase)) { /* */ }
        
        var token = authorization.Substring("accessToken".Length).Trim();
        // ...
    }
