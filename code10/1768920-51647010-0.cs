	string startTime = "2018-04-17 00:00:00.000";
	string endTime = "2018-04-17 23:59:59.997";
	string db = "database";
	List<ShelfInventoryModel> output = new List<ShelfInventoryModel>();
	using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlConnection.CnnString(db)))
	{
		DataTable dt = new DataTable();
		var p = new DynamicParameters();
		p.Add("@StartDate", startTime);
		p.Add("@EndDate", endTime);
		output = connection.Query<ShelfInventoryModel>("dbo.spGetInventory_Liquor", p, commandType: CommandType.StoredProcedure).ToList();
		foreach (ShelfInventoryModel item in output)
		{
			Console.WriteLine(item.Quantity.ToString());
			Console.WriteLine(item.ItemName);
		}		
	}
