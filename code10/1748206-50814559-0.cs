    Int32 total = 0; 
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total = total + Convert.ToInt32(e.Row.Cells[1].Text);
    		//here you can give the column no that you want to total like e.Row.Cells[1] for column 1
            lblTotal.Text = total.ToString();
        }
    }
