    int GroupCount = 0;
     for (int count = 0; count < grd.Rows.Count; count++)
    {
        int GroupNo = ((label)grd.Rows[count].FindControl("yourGroupNoLable")).Text;
        if (((CheckBox)grd.Rows[count].FindControl("yourCheckbox")).Checked)
        {
            GroupCount = GroupCount + 1;
        }
    }
    
