    if (Repeater1.Items.Count > 0)
        {
            for (int count = 0; count < Repeater1.Items.Count; count++)
            {
                CheckBox chk = (CheckBox)Repeater1.Items[count].FindControl("CheckBox1");
                if (chk.Checked)
                {
                }
            }
        }
