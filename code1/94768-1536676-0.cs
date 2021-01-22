    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Repeater1.Items.Count > 0) 
        { 
            for (int count = 0; count < Repeater1.Items.Count; count++) 
            {
                DropDownList ddl = (DropDownList)Repeater1.Items[count].FindControl("ddl");
               ddl.SelectedValue//
            } 
        }
    }
