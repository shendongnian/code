	public class BankAccount
	{
		[JsonIgnore]
		public double DoubleAmount { get; set; }
		public string FormattedAmount
		{
			get
			{
				return (this.DoubleAmount / 3).ToString() + "k"; // example
			}
		}
	}
