    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] MessageViewModel viewModel)
    {
    	var message = new Message
    	{
    		MessageBody = viewModel.MessageBody,
    		Recipients = viewModel.Users.Select(c => new MessageRecipients { UserId = c}).ToList()
    	};
    
    	_context.Messages.Add(message);
    	await _context.SaveChangesAsync();
    
    	return Ok();
    }
    
    public class MessageViewModel
    {
    	public string MessageBody { get; set; }
    
    	public IEnumerable<int> Users { get; set; }
    }
