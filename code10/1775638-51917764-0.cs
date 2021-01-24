    [HttpGet]
    [Produces("application/json")]
    [Route("whatever")]
    public ActionResult<JsonResult> Get()
    {
        string jsonText = "{\"city\":\"paris\"}";
        return new JsonResult(JObject.Parse(jsonText).ToString());
    }
