    protected void BtnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdreport.Rows.Count; i++)
        {
            GridViewRow row = grdreport.Rows[i];
            CheckBox checkbox1 = (CheckBox)row.FindControl("cb1");
            if (checkbox1.Checked)
            {
                Label1.Text += string.Format("Row {0}: {1}<br>", i, row.Cells[1].Text);
            }
        }
    }
