    foreach(ListViewDataItem myItem in myListView.Items)
    {
       RadioButton btn1 = (RadioButton)myItem.FindControl("radiobutton1");
       RadioButton btn2 = (RadioButton)myItem.FindControl("radiobutton2");
       RadioButton btn3 = (RadioButton)myItem.FindControl("radiobutton3");
    
       bool AtLeastOneChecked = btn1.Checked || btn2.Checked || btn3.Checked; 
    
    }
