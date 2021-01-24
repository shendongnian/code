    [HttpPost]
    public ActionResult AddMessage([FromBody] ShoutboxMessage input)
    {
        if (Request.Cookies["usrid"] == null)
            return this.RedirectToAction("Login");
    
        if (!string.IsNullOrWhiteSpace(input.Message))
        {
            //...
            return new EmptyResult();
        }
    }
