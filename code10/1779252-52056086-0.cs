    [HttpPost]
    public string SomePost()
    {
        // Check if it's a Form value
        if(Request.Form != null) { // do something }
        else if(Request.Body != null) { // do something }
    }
