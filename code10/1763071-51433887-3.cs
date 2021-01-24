	public async Task<IActionResult> CreateEvent(Event val)
	{
		_ctx.Event.Add(val);
		await _ctx.SaveChangesAsync();
		Task.Run(() => SendInvitation(val));
		return Ok();
	}
