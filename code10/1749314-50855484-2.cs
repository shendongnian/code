    [HttpPost]
    public IActionResult SaveServers([FromBody]DataCenter dataCenter)
    {
        var img = dataCenter.ImageServer as ImageServer;
        return Ok();
    }
