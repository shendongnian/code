    public static DataTable DtProjectLedgerExport(DataTable dtToExport, string[] selectedColumns, params string[] additionalColumns)
	{
		DataTable dt = dtToExport.Copy(); // add columns and data
		List<DataColumn> removeColumns = dt.Columns.Cast<DataColumn>()
			.Where(c => !selectedColumns.Contains(c.ColumnName, StringComparer.InvariantCultureIgnoreCase))
			.ToList();
		removeColumns.ForEach(dt.Columns.Remove);
		foreach (string colName in additionalColumns)
		{
			DataColumn newColumn = new DataColumn(colName);
			newColumn.DefaultValue = string.Empty;
			dt.Columns.Add(newColumn);
		}
		return dt;
	}
