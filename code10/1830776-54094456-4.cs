    public static class ObservableCollectionExtensions
    {
	public static ObservableCollection<T> SetValue<T>(this ObservableCollection<T> obc, int rowNumFromZero, int propNumFromZero, string str)
	{
		int rowCounter = -1;
		foreach (var itemObc in obc)
		{
			rowCounter++;
			PropertyInfo[] Fields = itemObc.GetType().GetProperties();
			int propCounter = -1;
			foreach (PropertyInfo field in Fields)
			{
				propCounter++;
				if (rowCounter == rowNumFromZero)
				{
					var currentField = field.GetValue(itemObc, null);
					if (currentField != null)
					{
						var t = currentField.GetType();
						if (t == typeof(string) && propCounter == propNumFromZero)
							field.SetValue(itemObc, str);
					}
				}
			}
		}
		return obc;
	}
