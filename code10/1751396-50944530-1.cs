    [HttpPost(Name = "add-message")]
    public async Task<IActionResult> PostMessage(
        [FromBody] MessengerViewModel messengerViewModel,
        [FromServices] TaskQueue taskQueue,
        [FromServices] SerialQueue serialQueue)
    {
        await taskQueue.Enqueue(
            () => SendMessage(
                      messengerViewModel.PhoneNr, 
                      messengerViewModel.MessageBody,
                      messengerViewModel.ContactId, 
                      messengerViewModel.State));
        //I'm not running tasks at same time, using one or other at time
        await serialQueue.Enqueue(
            () => SendMessage(
                      messengerViewModel.PhoneNr, 
                      messengerViewModel.MessageBody,
                      messengerViewModel.ContactId, 
                      messengerViewModel.State));
        return Ok();
    }
