	public static List<MapDataList> CreateMapData(double[] coordinates, double[] values )
	{
    	MapDataList mdl = new MapDataList
		{
			Coordinates = coordinates.ToList(),
			Values = values.ToList()
		};
    	return new List<MapDataList> { mdl };
	}
