    foreach (GridViewRow row in GridView2.Rows)
    {
        CheckBox chk = row.FindControl("CheckBoxName") as CheckBox;
        if (chk != null && chk.Checked)
        {
            // delete from data source (e.g. DataTable), not GridView row
            dt.Rows.RemoveAt(row.RowIndex);
            // you can execute delete query against DB here
        }
    }
    
    // rebind the grid
    GridView2.DataSource = dt;
    GridView2.DataBind();
