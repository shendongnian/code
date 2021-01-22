    CheckBox chkBx = new CheckBox();
    
    for (int i = 0; i < grdView.Rows.Count; ++i)
    {
    chkBx = (CheckBox)grdView.Rows[i].FindControl("yourCheckBoxIDInHTMLView");
     if (chkBx.Checked == true)
     {
      // Do some work here
     }
    }
