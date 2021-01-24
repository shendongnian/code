	public DataTable jsonDataDiplay()
	{
	    StreamReader sr = new StreamReader(Server.MapPath("TrainServiceAlerts.json"));
        string json = sr.ReadToEnd();
	    dynamic table = JsonConvert.DeserializeObject(json);
		DataTable newTable = new DataTable();
		newTable.Columns.Add("Line", typeof(string));
		newTable.Columns.Add("Direction", typeof(string));
		newTable.Columns.Add("Stations", typeof(string));
		newTable.Columns.Add("MRTShuttleDirection", typeof(string));
		
		foreach (var row in table.value.AffectedSegments)
		{
			newTable.Rows.Add(row.Line, row.Direction, row.Stations, row.MRTShuttleDirection);
		}
		return newTable;
	}
