	class Price
	{
		private int priceInCents;
		private bool displayCents;
		private Func<string> displayFunction;
		public Price(int dollars, int cents)
		{
			priceInCents = dollars*100 + cents;
			DisplayCents = true;
		}
		public bool DisplayCents
		{
			get { return displayCents; }
			set
			{
				displayCents = value;
				if (displayCents)
				{
					this.displayFunction = () => String.Format("{0}.{1}", priceInCents / 100, priceInCents % 100);
				}
				else
				{
					this.displayFunction = () => (priceInCents / 100).ToString();
				}
			}
		}
		public string ToString()
		{
			return this.displayFunction();	
		}
	}
