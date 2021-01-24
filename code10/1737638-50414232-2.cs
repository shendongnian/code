    [HttpPost]
    [Authorize]
    [Route("{connectionId}")]
    public IActionResult Post(string connectionId)
    {
        this.hubConnectionService.AddConnection(connectionId, this.workContext.CurrentUserId);
        return this.Ok();
    }
