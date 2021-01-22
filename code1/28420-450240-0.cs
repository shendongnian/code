    protected void gvUserData_OnRowEditing(object sender, GridViewEditEventArgs  e)
    {
        gvUserData.EditIndex = e.NewEditIndex;
        gvUserData.DataSource = _section.GetUserEntries();
        gvUserData.DataBind();
        DropDownList tempddl = new DropDownList();       //I am not sure whether this is correct or not..        
        tempddl = (DropDownList)gvUserData.FindControl("ddlTypeListInGrid");
        tempddl.DataSource = _section.GetTypeEntries();
        tempddl.DataBind();        
        
    }
