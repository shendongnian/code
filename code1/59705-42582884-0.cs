    foreach (PropertyInfo property in typeof(YourType).GetProperties())
    {
	  if (property.CanWrite)
	  {
		property.SetValue(marketData, property.GetValue(market, null), null);
	  }
    }
