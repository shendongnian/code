    private static string FormatByGridView(object value, string DataFormatString)
	{
		GridView grid = new GridView();
		DataTable table = new DataTable();
		table.Columns.Add("value", value.GetType());
		var row = table.NewRow();
		row["value"] = value;
		table.Rows.Add(row);
		grid.Columns.Add(new BoundField() { DataField = "value", DataFormatString = DataFormatString });
		grid.DataSource = table;
		grid.DataBind();
		return grid.Rows[0].Cells[0].Text;
	}
