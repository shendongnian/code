    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //locate the hyperlink in the correct cell nummer. It is always the first control in the cell
            HyperLink hl = e.Row.Cells[colIndex].Controls[0] as HyperLink;
            //validate the value
            if (row["Security"].ToString() == "Security")
            {
                hl.Visible = false;
            }
        }
    }
