	DateTime sixMonthsAgo = DateTime.Today.AddMonths(-6);
	int pageIndex = 1; // Would be passed in
	int pageSize = 3;
	IQueryable<OrganizationViewModel> query = _context.Organizations
		.AsNoTracking()
		.Select(organization => new OrganizationViewModel
		{
			CommunicationViewModels = organization.Communications.Select(communication  => 
				new CommunicationViewModel
				{
					Id = communication.Id,
					Date = communication.Date
				})
				.OrderByDescending(communicationViewModel => communicationViewModel.Date)
				.Take(1)
				.Where(communicationViewModel => communicationViewModel.Date <= sixMonthsAgo)
				.AsQueryable()
		})
		.Where(organizationViewModel =>
			(!searchViewModel.LimitToLastSixMonths || organizationViewModel.CommunicationViewModels.Any()));
	int totalAmount = await query.CountAsync();
	List<OrganizationViewModel> items = await query
				.Skip((pageIndex - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
