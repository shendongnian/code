    [HttpGet]
    public ActionResult<ContentModel> Get()
    {
        var model = new ContentModel
        {
            Total = 12
        };
        return Ok(model);
    }
