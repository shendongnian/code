    protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // set first cell in the row to color just for demonstration purpose.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
        {
            e.Row.Cells[0].Text = ((GridView)sender).AlternatingRowStyle.BackColor.ToString();
        }
    }
