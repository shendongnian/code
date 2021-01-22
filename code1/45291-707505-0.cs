	protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			string value = e.Row.Cells[1].Text;
			if (!string.IsNullOrEmpty(value))
			    e.Row.Cells[1].Text = value.Insert(value.Length / 2, " ");
		}
	}
