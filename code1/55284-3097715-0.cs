    public void txtPrice_TextChanged(object sender, EventArgs e)
    {
        TextBox txtPrice = (TextBox)sender;
        DataGridItem myItem = (DataGridItem)txtPrice.Parent.Parent;
        markRows(myItem, true);
    }
    public void markRows(DataGridItem myItem, bool toSave)
    {
        // Prepeare to save this record?
        CheckBox thisSave = (CheckBox)myItem.FindControl("chkSave");
        thisSave.Checked = toSave;
        // Establish the row's position in the table
        Label sNo = (Label)myItem.FindControl("SNo");
        int rowNum = Convert.ToInt32(sNo.Text) - 1;
        CheckBox rowSave = (CheckBox)grid.Items[rowNum].FindControl("chkSave");
        // Update background color on the row to remove/add highlight 
        if (rowSave.Checked == true)
            grid.Items[rowNum].BackColor = System.Drawing.Color.GreenYellow;
        else
        {
            Color bgBlue = Color.FromArgb(212, 231, 247);
            grid.Items[rowNum].BackColor = bgBlue;
            // some code here to refresh data from table?
        }
    }
