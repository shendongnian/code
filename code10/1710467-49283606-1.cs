    abstract class Element
	{
		public FinancialTransactionObject result { get; private set; }
		protected void Accept(ICalculator calculator)
		{
			this.result = calculator.Calculate(this);
		}
	}
