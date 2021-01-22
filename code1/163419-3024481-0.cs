	public static void PrintSeriesList()
	{
		SampleChartData myList = new SampleChartData();
		
		PropertyInfo[] Fields = myList.GetType().GetProperties();
		
		foreach(PropertyInfo field in Fields)
		{
			var currentField =  field.GetValue(myList, null);
			if (currentField.GetType() == typeof(List<Point>))
			{
				Console.WriteLine("List {0} count {1}", field.Name, ((List<Point>)currentField).Count);
			}
		}
	}
