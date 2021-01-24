    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Select")
                {
                      int selectedRowIndex = Convert.ToInt32(e.CommandArgument);
                      GridViewRow gv = GridView1.Rows[selectedRowIndex];
    
                      // Rest of the code
                }
             }
