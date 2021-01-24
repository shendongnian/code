    var payments = ctx.Payments.ToList();
	var data = (
		from p in ctx.Activities.ToList()
		orderby p.ID
		let paymentCount = payments.Where(q => q.ActivityID == p.ID && !q.Paid).Count()
		select new
		{
			ID = p.ID,
			Date = p.Date?.ToString("dd/MM/yyyy"),
			PaymentMethod = p.PaymentMethods != null ? p.PaymentMethods.Description : "",
			ActivityStatusID = paymentCount == 0 ? 1 : .. // I need some other check
		}
	).ToList();
