    private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
    if(e.Item.ItemType==System.Web.UI.WebControls.ListItemType.EditItem)
    
    RadioButton rBtnTest = e.Item.FindControl("radiobutton id") as RadioButton;
    // Check condition and if it's true
    if(your_condition == true)
     rBtnTest.Checked = true;
    else
     rBtnTest.Checked = false;
    }
