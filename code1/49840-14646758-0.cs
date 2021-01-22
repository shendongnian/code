        CheckBox selectall = (CheckBox)EmployeeGrid.HeaderRow.FindControl("gcb_selectall");
        ArrayList cbstatuslist = new ArrayList();
        if (Session["childcbstatus"] != null)
        {
            cbstatuslist = (ArrayList)Session["childcbstatus"];
        }
        foreach (GridViewRow row in EmployeeGrid.Rows)
        {
            int cb_index = (int)row.DataItemIndex;  //For Getting DataItemIndex of EmployeeGrid 
            //int cb_index = (int)row.RowIndex;
            CheckBox cb_selemp = (CheckBox)row.FindControl("gcb_selemp");
            CheckBox cb_active = (CheckBox)row.FindControl("gcb_active");
            if (cb_selemp.Checked == true)
            {
                if (!cbstatuslist.Contains(cb_index))
                    cbstatuslist.Add(cb_index);
            }
            else
            {
                cbstatuslist.Remove(cb_index);
            }
        }
        Session["childcbstatus"] = cbstatuslist;
    }
