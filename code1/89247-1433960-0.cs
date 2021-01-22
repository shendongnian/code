    protected void ddlYourDDL_DataBinding(object sender, System.EventArgs e)
    {
        DropDownList ddl = (DropDownList)(sender);
        for (int i = 1; i < 5; i++)
        {
             ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        
        // Now that the items are all there, set the selected property
        ddl.SelectedValue = Eval("selectedfieldname").ToString();
     }
