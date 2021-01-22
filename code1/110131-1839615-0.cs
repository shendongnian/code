    Boolean Selected = false;
        for (int count = 0; count < grd.Rows.Count; count++)
        {
            if (((CheckBox)grd.Rows[count].FindControl("yourCheckbox")).Checked)
            {
                Selected = true;
            }
        }
    if (Selected == false)
        {
            //your message goes here.
        }
