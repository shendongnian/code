    protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {            
	    TextBox txt = new TextBox();
              // set properties of text box
	    e.Row.Cells[0].Controls.Add(txt);
        }
    }
