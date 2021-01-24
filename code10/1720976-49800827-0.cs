    protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //create a dropdownlist and add some data
            DropDownList ddl = new DropDownList();
            ddl.ID = "ddlStatus";
            ddl.Items.Add(new ListItem() { Text = "Option 1", Value = "1" });
            ddl.Items.Add(new ListItem() { Text = "Option 2", Value = "2" });
            ddl.Items.Add(new ListItem() { Text = "Option 3", Value = "3" });
            //create a save button
            Button btn = new Button();
            btn.ID = "btnSave";
            btn.CommandName = "save";
            btn.Text = "Save";
            btn.CommandArgument = e.Row.RowIndex.ToString();
            //add the controls to the last 2 cells
            e.Row.Cells[e.Row.Cells.Count - 2].Controls.Add(ddl);
            e.Row.Cells[e.Row.Cells.Count - 1].Controls.Add(btn);
        }
    }
