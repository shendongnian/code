    public ActionResult MultipleParameters()
    {
        var parameters = HttpContext.Request.Query;
        return Ok(parameters.ToList());
    }
