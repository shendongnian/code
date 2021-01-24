    public static List<Point> ToPoints(this ObservableCollection<MyPoint> list)
	{
		var result = new List<Point>();
		foreach (var item in list)
		{
			result.Add(item.ToPoint());
		}
		return result;
	}
