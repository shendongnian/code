	public async Task<IActionResult> CreateEvent(Event val)
	{
		_ctx.Event.Add(val);
		await _ctx.SaveChangesAsync();
		await SendInvitation(val);
		return Ok();
	}
	
	public async Task SendInvitation(Event @event)
	{
		foreach (var person in @event.people)
		{
			await _ctx.Invitation.Add(person);
			await _ctx.SaveChangesAsync();
			await _mailService.SendMail(person.email, "you have been invited");
		}
	}
