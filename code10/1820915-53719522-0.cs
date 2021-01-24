	public async Task<IActionResult> Index()
	{
			List<MessageModel> models =await ListTemplatesAsync();
			await StartEnvironmentAsync();
			return View(models);
	}
	private async Task<List<MessageModel>> ListTemplatesAsync(List<MessageModel> models)
	{
		var response = await GetEnvironments.OnMessageReceiptAsync();
		List<MessageModel> models = new List<MessageModel>();
		foreach (var msg in response)
		{
			models.Add(new MessageModel(msg.MessageId, msg.Body, msg.MessageAttributes, msg.ReceiptHandle));
		}
		return models ;
	}
