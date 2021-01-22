        for (int i = 0; i < grdList.Rows.Count; i++)
        {
            string key = grdList.DataKeys[i].Value.ToString();
            if (((CheckBox)grdList.Rows[i].FindControl("chkSelect")).Checked)
                foreach (TargetObject obj in objects)
                    if (obj.Key == key)
                    {
                        //do something like below
                        flag = true;
                        break;
                    }
        }
