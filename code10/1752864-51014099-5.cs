    [HttpGet]
    public async Task<ActionResult> GetMessages()
    {
      var result = await _messageClient.ReadMessages();
      return Ok(result);
    }
