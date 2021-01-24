    foreach (GridViewRow row in GridViewAppts.Rows)
    {
        if (row.RowType == DataControlRowType.DataRow)
        {
            // 'n' belongs to column index, starting from leftmost column = 0
            if (row.Cells[n].Text == "NO")
            {
                row.Visible = false;
            }
        }
    }
