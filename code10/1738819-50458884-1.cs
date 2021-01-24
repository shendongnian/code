    for (int i = 0; i < GridViewAppts.Rows.Count; i++)
    {
        // 'n' belongs to column index, starting from leftmost column = 0
        if (GridViewAppts.Rows[i].Cells[n].Text == "NO")
        {
            GridViewAppts.Rows[i].Visible = false;
        }
    }
