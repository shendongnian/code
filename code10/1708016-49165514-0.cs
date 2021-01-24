	public string GetWholesalePrice(string priceIn)
	{
		decimal price = decimal.Parse(priceIn);
		string priceOut = string.Empty;
		//for loop for the class wholesale to set
		for (int i = 5; i < 11; i++)
		{
			decimal percent = i / 100m;
			decimal wsale = price * percent;
			priceOut += string.Format(" Markup of {0} percent is {1:c}\n", i, wsale);
		}
		return priceOut;
	}
	
