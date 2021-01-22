    protected void MyRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        DropDownList myDDL;
        myDDL = (DropDownList) e.Item.FindControl("GeneralDDL");
        System.Diagnostics.Debug.WriteLine(myDDL.SelectedValue);
    }
