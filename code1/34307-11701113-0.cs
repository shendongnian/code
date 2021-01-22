    int i = 0;
    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox chk = (CheckBox)GridView_AdminTags.Rows[i].Cells[0].FindControl("chkTag");
        if (chk != null)
            if (chk.Checked)
            {
                ////.......;
            }
        i++;
    }
    i = 0;
