    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //ASSUMES COLUMN 2 IS DATE
            //AND COLUMN 3 IS TIME
            e.Row.Cells[2].Text = e.Row.Cells[2].Text + " " + e.Row.Cells[3].Text;
            e.Row.Cells[3].Visible = false;
        }
    }
