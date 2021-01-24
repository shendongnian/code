            List<string> sortOrder = new List<string> { "Attended", "Issued", "Unpaid", "Cancelled" };
			dt = dt.AsEnumerable()
				.OrderBy(x => sortOrder.IndexOf(x["TicketStatus"].ToString()))
				.GroupBy(x => new {EventID = x["EventID"].ToString(), ContactID = x["ContactID"].ToString()})
				.Select(x => x.FirstOrDefault()).CopyToDataTable();
