	public class Invoice
	{
		public int TotalCouponsNeeded { get; set; }
		public int UsedCouponCount { get; set; }
		public List<UsedCouponsForMonth> UsedCoupons { get; set; }
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			if (UsedCouponCount == 0)
			{
				sb.Append("0 coupons have been used");
			}
			else
			{
				sb.AppendFormat("{0} have been used ({1})",
						UsedCouponCount,
						String.Join(", ", UsedCoupons.Select(x => String.Format("{0} in {1:MMM yyyy}", x.Count, new DateTime(x.Year, x.Month, 1))))
					);
			}
			sb.AppendFormat(", {0} dollars still needs to be paid by client.", 25 * (TotalCouponsNeeded - UsedCouponCount));
			return sb.ToString();
		}		
	}
	
	public class UsedCouponsForMonth
	{
		public int Month { get; set; }
		public int Year { get; set; }
		public int Count { get; set; }
	}
