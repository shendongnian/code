    protected void LinkButton1_Click(object sender, EventArgs e)
     {
    LinkButton btn = (LinkButton)sender;
    GridViewRow row = (GridViewRow)btn.NamingContainer;
    string machineID = (String)GridView1.SelectedValue;
    if (row != null)
    {
    LinkButton LinkButton1 = (LinkButton)sender;
    // Get reference to the row that hold the button
    GridViewRow gvr = (GridViewRow)LinkButton1.NamingContainer;
    HiddenField hdn=(HiddenField)gvr.FindControl("hdn");
    // get the value of MachineGroupID for the row.
    string mcgID= hdn.value;
    
    //--------- Write delete code here-------//
     }
     }
