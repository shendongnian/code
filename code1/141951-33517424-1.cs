	public static bool ChangeColumnDataType(DataTable table, string columnname, Type newtype){
		if (table.Columns.Contains(columnname) == false)
			return false;
	
		DataColumn column = table.Columns[columnname];
		if (column.DataType == newtype)
			return true;
	
		try{
			DataColumn newcolumn = new DataColumn("temporary", newtype);
			table.Columns.Add(newcolumn);
			
            foreach (DataRow row in table.Rows){
				try{
					row["temporary"] = Convert.ChangeType(row[columnname], newtype);
				}
				catch{}
			}
			newcolumn.SetOrdinal(column.Ordinal);
			table.Columns.Remove(columnname);
			newcolumn.ColumnName = columnname;
		}
		catch (Exception){
			return false;
		}
	
		return true;
	}
