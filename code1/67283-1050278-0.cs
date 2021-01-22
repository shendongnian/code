    	public static DataTable GetCSVRows(string path, bool IsFirstRowHeader)
	{
		string header = "No";
		string sql = string.Empty;
		DataTable dataTable = null;
		string pathOnly = string.Empty;
		string fileName = string.Empty;
		try
		{
			pathOnly = Path.GetDirectoryName(path);
			fileName = Path.GetFileName(path);
			sql = @"SELECT * FROM [" + fileName + "]";
			if(IsFirstRowHeader)
			{
				header = "Yes";
			}
			using(OleDbConnection connection = new OleDbConnection(
				@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly + 
				";Extended Properties=\"Text;HDR=" + header + "\""))
			{
				using(OleDbCommand command = new OleDbCommand(sql, connection))
				{
					using(OleDbDataAdapter adapter = new OleDbDataAdapter(command))
					{
						dataTable = new DataTable();
						dataTable.Locale = CultureInfo.CurrentCulture;
						adapter.Fill(dataTable);
					}
				}
			}
		}
		finally
		{
		}
		return dataTable;
	}
