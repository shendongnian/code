	protected void grid_RowCreated(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			//assuming that a first cell is a ButtonField
			//note that in edit mode a button may be at some other index that 0
			Button btn = e.Row.Cells[0].Controls[0] as Button;
			if (btn != null)
			{
				btn.OnClientClick = "return confirm('are you sure?')";
				btn.ID = "myButtonX";
			}
		}
	}
