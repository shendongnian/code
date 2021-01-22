    protected void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        double dVal = 0.0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            dVal += Convert.ToDouble(e.Row.Cells[1].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = dVal.ToString("c");
        }
    }
