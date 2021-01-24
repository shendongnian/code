    public static DataTable SupressDataTable(DataTable cases)
	{
		DataTable suppressedDataTable = cases.Copy(); // Same columns, same data
		DataColumn[] allNumericColumns = suppressedDataTable.Columns.Cast<DataColumn>().Where(IsNumeric).ToArray();
		foreach (DataColumn numericCol in allNumericColumns)
		{
			int ordinal = numericCol.Ordinal; // need to store before remove
			suppressedDataTable.Columns.Remove(numericCol);
			suppressedDataTable.Columns.Add(numericCol.ColumnName); // string column
			suppressedDataTable.Columns[numericCol.ColumnName].SetOrdinal(ordinal);
		}
		for (int index = 0; index < suppressedDataTable.Rows.Count; index++)
		{
			DataRow row = suppressedDataTable.Rows[index];
			foreach (DataColumn column in cases.Columns)
			{
				if (IsNumeric(column))
				{
					dynamic numVal = cases.Rows[index][column];
					string newValue = numVal > 0 && numVal < 5 ? "*" : numVal.ToString();
					row.SetField(column.Ordinal, newValue);
				}
			}
		}
		return suppressedDataTable;
	}
