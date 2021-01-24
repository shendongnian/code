	public class BankAccount
	{
		[JsonIgnore]
		public double DoubleAmount { get; set; }
		public string FormattedAmount => $"{this.DoubleAmount / 3}k";
	}
