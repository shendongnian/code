    protected override async Task RouteAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
    {
		if (string.IsNullOrEmpty(activity.Text))
		{
			dynamic value = dc.Context.Activity.Value;
			await turnContext.SendActivityAsync($"Ticket = {value[TICKETFIELD]}, Summary = {value[SUMMARYFIELD]}, Status = {value[STATUSFIELD]}");
		}
		else
		{
			// All the code that was already there
		}
	}
