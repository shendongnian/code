    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e) {
        CheckBoxList cbl = sender as CheckBoxList;
        Response.Write(cbl.SelectedIndex);
        Response.Write(cbl.SelectedItem);
    }
