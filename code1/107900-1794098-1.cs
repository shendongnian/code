    protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.Cells[1].Text == "Cancelled")
        {
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
        }
    }
