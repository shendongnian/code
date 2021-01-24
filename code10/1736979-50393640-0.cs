    public bool isRowEmpty(DataTable dt, int index)
	{
		DataRow row = dt.Rows[index];
		return dt.Columns.Cast<DataColumn>()
            .All(c => row.IsNull(c) || string.IsNullOrWhiteSpace(row[c].ToString()));
	}
