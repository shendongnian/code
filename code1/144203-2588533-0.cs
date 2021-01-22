	var table = adapter.GetData(); //get data from repository object -> DataTable
	IList<IHouseAnnouncement> list = new List<IHouseAnnouncement>(table.Rows.Count);
	for (int i = 0; i < list.Length; i++)
	{
	   list[i] = new HouseAnnouncement();
	   list[i].Area = float.Parse(table.Rows[i][table.areaColumn].ToString());
	   list[i].City = table.Rows[i][table.cityColumn].ToString();
	}
	return list;
