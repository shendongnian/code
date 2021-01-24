    public class Sale
	{
		private List<Payment> Payments {get;set;}       // initialize in constructor
		private decimal _sumPointsAmount;
		public decimal LoyaltyRate { get; private set; } // set via constructor
		public decimal PointsPaid => _sumPointsAmount * LoyaltyRate;
	
		public void AddPayment(Payment p)
		{
			Payments.Add(p);
			if (p.PaymentType == PaymentType.Points)
				_sumPointsAmount += p.Amount;
		}
		public bool RemovePayment(Payment p)
		{
			bool removed = Payments.Remove(p);
			if(removed && p.PaymentType == PaymentType.Points)
				_sumPointsAmount -= p.Amount;
            return removed;
		}
	}
