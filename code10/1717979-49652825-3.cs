    // Getting GridView row which clicked
    GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
    // Check if LinkButton (AddRow) is clicked
    if (e.CommandName=="AddRow")
    {
        // getting the value of label inside GridView
        string rowCellValue = ((Label)row.FindControl("Label1")).Text;
        // setting value to TextBox which is inside First UpdatePanel
        txtTotal.Text = rowCellValue;
    }
