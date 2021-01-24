		IHubContext<MessageHub, ITypedHubClient> _messageHubContext;
		public async Task<IActionResult> Test()
		{
			await _messageHubContext.Clients.All.SendMessageToClient("test", "test", "test");
			return Ok("ok");
		}
