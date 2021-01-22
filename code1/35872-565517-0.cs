    protected void MyDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        RadioButton myRadioButton = e.Items.FindControl("myRadioButton") as RadioButton;
        
        if (myRadioButton == null) { }
        else
        {
            if (string.IsNullOrEmpty(Session[myRadioButton.Value])) {}
            else myRadioButton.Checked = true;        
        }
    }
