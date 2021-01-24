    public IHttpActionResult AddToConversation([FromBody]SentMessage message)
    {
        if (message is null)
        {
            return NotFound();
        }
    
        return Ok("Message Sent");
    }
 
