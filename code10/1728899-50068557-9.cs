	public class BankAccount
	{
		[JsonIgnore]
		public double DoubleAmount { get; set; }
		public string FormattedAmount
		{
			get
			{
				return (this.DoubleAmount / 1000).ToString() + "k"; // example
			}
		}
	}
