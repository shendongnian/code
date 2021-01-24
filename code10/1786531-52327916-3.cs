	public static List<MapDataList> CreateMapData(double[] coordinates, double[] values )
	{
    	return new List<MapDataList> { new MapDataList
		{
			Coordinates = coordinates.ToList(),
			Values = values.ToList()
		}};
	}
