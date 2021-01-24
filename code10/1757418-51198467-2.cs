	public Invoice GenerateInvoice(int companyId, int maxMonths, int couponsNeeded)
	{
		Invoice invoice = new Invoice
		{
			TotalCouponsNeeded = couponsNeeded,
			UsedCouponCount = 0,
			UsedCoupons = new List<UsedCouponsForMonth>(),
		};
		
		for (int i = 0; i < maxMonths && invoice.UsedCouponCount < invoice.TotalCouponsNeeded; i++)
		{
			DateTime month = DateTime.Now.AddMonths(i - maxMonths + 1);
			int availableForMonth = GetCouponAmountByMonth(companyId, month.Year, month.Month);
			if (availableForMonth <= 0)
			{
				continue;
			}
			int usedThisMonth = (invoice.UsedCouponCount + availableForMonth < invoice.TotalCouponsNeeded)
				? availableForMonth
				: (couponsNeeded - invoice.UsedCouponCount);
			invoice.UsedCouponCount += usedThisMonth;
			SubtractCoupons(companyId, month.Year, month.Month, usedThisMonth);
		}
		
		return invoice;
	}
