    public static IEnumerable<Dictionary<string, object>> ToDictionary(this DataTable table)
    {
    	string[] columns = table.Columns.Cast<DataColumn>().Select(c=>c.ColumnName).ToArray();
    	IEnumerable<Dictionary<string, object>> result = table.Rows.Cast<DataRow>()
    		.Select(dr => dr.ItemArray.Select((value, index) => new { value, index })
    		.ToDictionary(k => columns[k.index], v => v.value));
    	return result;
    }
