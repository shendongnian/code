    foreach(DataTable table in dataSet.Tables)
    {
		SQLiteCommand cmd = new SQLiteCommand(mDBcon);
		cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + table.Name + "(";
		bool first = true;
		foreach (DataColumn column in table.Columns)
		{			
			cmd.CommandText += "@"+column.Name;
			if (!first) cmd.CommandText += ",";
			else first = false;
			cmd.Parameters.Add(new SQLiteParameter("@"+column.Name, column.Name));
		}
		cmd.CommandText += ");";
		cmd.ExecuteNonQuery();
		
		// Fill the new table:
		SQLiteDataAdapter da = new SQLiteDataAdapter("select * from " + table.Name, mDBcon);
		da.Fill(table);
    }
	
