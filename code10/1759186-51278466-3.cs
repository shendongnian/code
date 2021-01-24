    [HttpPost]
    [Route("message")]
    public async Task<IActionResult> SendMessageUser([FromBody]Message request)
    {
        try
        {
            await _fifoSemaphore.WaitAsync();
            // process message code here
        }
        finally // important to have a finally to release the semaphore, so that even in the case of an exception, it can continue to process the next message
        {
            _fifoSemaphore.Release();
        }
    }
