    for(int i = GridView1.Rows.Count - 1; i >= 0; i--)
    {
        var row = GridView1.Rows[i];
        CheckBox chk = row.FindControl("chkInvoice") as CheckBox;
        if (chk != null && chk.Checked)
        {
           dt.Rows.RemoveAt(i);
        }
    }
