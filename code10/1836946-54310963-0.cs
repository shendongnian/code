	IQueryable<Bill> groupedBills;
	if (group == BillGroup.Customer)
	{
		groupedBills = dbo.Bill.GroupBy(c => c.Customer);
	}
	else
	{
		groupedBills = dbo.Bill.GroupBy(c => conta.BankAccount);
	}
	return groupedBills.Select(c => new BillDTO 
	{ 
		Nome = c.Nome,
		// ...
	});
