    [HttpPost]
    public ActionResult Post([FromBody]ValueModel value)
    {
        return new OkObjectResult($"MinX={value.MinX}; MinY={value.MinY}");
    }
