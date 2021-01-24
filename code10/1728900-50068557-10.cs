	public class BankAccount
	{
		[JsonIgnore]
		public double DoubleAmount { get; set; }
		public string FormattedAmount => $"{this.DoubleAmount / 1000}k";
	}
