      protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "Delete")
                {
                  //Update the flag in datasource using the CommandArgument  value
                  //Bind the datasource again.
                }
            }
            protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            }
