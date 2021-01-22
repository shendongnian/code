	protected void yourGrid_RowDataBound(object sender, GridViewRowEventArgs e)
	{
			HyperLink hlControl = new HyperLink();
			hlControl.Text = e.Row.Cells[2].Text; //Take back the text (let say you want it in cell of index 2)
			hlControl.NavigateUrl = "http://www.stackoverflow.com";
			e.Row.Cells[2].Controls.Add(hlControl);//index 2 for the example
	}
