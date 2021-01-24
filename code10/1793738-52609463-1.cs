    public SomeResult ProcessForm([FromBody]Dictionary<string,string> contactFormRequest)
    {
        var message = "test";
        var result = true;
        return new SomeResult{Message = message, Result = result};
    }
