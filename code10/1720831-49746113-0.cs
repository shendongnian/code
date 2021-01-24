    [HttpGet]
    public void SomeMethod()
    {
        var x = HttpContext.User;
        var y = x?.Claims;
        LambdaLogger.Log(y);
    }
