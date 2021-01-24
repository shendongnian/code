	var list = new[]
	{
		new { A = 1, TicketStatus = "Issue" },
		new { A = 2, TicketStatus = "Attended" },
		new { A = 3, TicketStatus = "Unpaid" },
		new { A = 4, TicketStatus = "Attended" },
		new { A = 5, TicketStatus = "Unpaid" },
	};
	var xxx = list.OrderBy( x => x.TicketStatus, new TicketStatusComparer() ).ToList();
